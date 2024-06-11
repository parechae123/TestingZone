using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using Tarodev_Pathfinding._Scripts.Units;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

namespace Tarodev_Pathfinding._Scripts.Grid {
    public class GridManager : MonoBehaviour {
        public static GridManager Instance;

        [SerializeField] private Sprite _playerSprite, _goalSprite;
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private ScriptableGrid _scriptableGrid;
        [SerializeField] private bool _drawConnections;
        public Dictionary<Vector2, NodeBase> Tiles { get; private set; }
        public PlayerStat playerStat = new PlayerStat();
        public NodeBase _playerNodeBase, _goalNodeBase;
        public NodeBase _PlayerStandingNode
        {
            get { return _playerNodeBase; }
            set 
            {
                if (_playerNodeBase != value)
                {
                    /*_spawnedPlayer.transform.DOComplete();
                    _spawnedPlayer.transform.DOKill();*/
                    Vector3 tempVec = value.transform.position - _playerNodeBase.transform.position;
                    tempVec = tempVec / 2f;

                    _spawnedPlayer.transform.DOMove(tempVec+ _playerNodeBase.transform.position, (1f / playerStat.moveSpeed)/2f).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        _playerNodeBase = value;
                        _playerNodeBase.SetColor(Color.white);
                        _spawnedPlayer.transform.DOMove(value.transform.position, (1f / playerStat.moveSpeed) / 2f).SetEase(Ease.Linear);
                    });
//                    _spawnedPlayer.transform.DOMove(_playerNodeBase.transform.position + tempVec, (1f / playerStat.moveSpeed) /2f);
//                    _spawnedPlayer.transform.DOMove(value.transform.position , (1f / playerStat.moveSpeed) / 2f);
                    if (_outPutNodes.Count > 0 )
                    {
                        if (_outPutNodes[_outPutNodes.Count - 1] == value) 
                        { 
                             _outPutNodes.Clear();
                            ResetMoveTimers();
                            _states = PlayerStates.standing;
                        }

                    }

                }


            }
        }
        private Unit _spawnedPlayer, _spawnedGoal;
        public List<NodeBase> _outPutNodes = new List<NodeBase>();

        PlayerStates _states;
        public float moveTargetTime = 0;
        public float movingTimer = 0;
        void Awake() => Instance = this;

        private void Start() {
            Tiles = _scriptableGrid.GenerateGrid();
            _states = PlayerStates.standing;
            foreach (var tile in Tiles.Values) tile.CacheNeighbors();

            SpawnUnits();
            NodeBase.OnHoverTile += OnTileHover;
        }

        private void OnDestroy() => NodeBase.OnHoverTile -= OnTileHover;

        private void OnTileHover(NodeBase nodeBase) {
            //클릭시 실행되는 함수, 여기에 있는 포지션값을 바꾸면될듯
            _goalNodeBase = nodeBase;
            _spawnedGoal.transform.position = _goalNodeBase.Coords.Pos;

            foreach (var t in Tiles.Values) t.RevertTile();

            var path = Pathfinding.FindPath(_playerNodeBase, _goalNodeBase);
            Debug.Log(_outPutNodes.Count);
        }
        public void MovePlayer(NodeBase targetNode)
        {
            _playerNodeBase.SetColor(Pathfinding.OpenColor);
            _playerNodeBase = targetNode;

/*            foreach (var t in Tiles.Values) t.RevertTile();

            List<NodeBase> path = Pathfinding.FindPath(_playerNodeBase, _goalNodeBase);*/
        }
        void SpawnUnits() {
            _playerNodeBase = Tiles.Where(t => t.Value.Walkable).OrderBy(t => Random.value).First().Value;
            _spawnedPlayer = Instantiate(_unitPrefab, _playerNodeBase.Coords.Pos, Quaternion.identity);
            _spawnedPlayer.Init(_playerSprite);

            _spawnedGoal = Instantiate(_unitPrefab, new Vector3(50, 50, 50), Quaternion.identity);
            _spawnedGoal.Init(_goalSprite);
        }

        public NodeBase GetTileAtPosition(Vector2 pos) => Tiles.TryGetValue(pos, out var tile) ? tile : null;

        private void OnDrawGizmos() {
            if (!Application.isPlaying || !_drawConnections) return;
            Gizmos.color = Color.red;
            foreach (var tile in Tiles) {
                if (tile.Value.Connection == null) continue;
                Gizmos.DrawLine((Vector3)tile.Key + new Vector3(0, 0, -1), (Vector3)tile.Value.Connection.Coords.Pos + new Vector3(0, 0, -1));
            }
        }
        public void Update()
        {
            if (_outPutNodes.Count > 0)
            {

                if (Input.GetKeyDown(KeyCode.Space) && _states != PlayerStates.walking)
                {

                    ResetMoveTimers();
                    movingTimer = 0;
                    _states= PlayerStates.walking;
                }

            }
            switch (_states)
            {
                case PlayerStates.walking:
                    movingTimer += Time.deltaTime;
                    if (movingTimer >= moveTargetTime)
                    {
                        ResetMoveTimers();
                        _states = PlayerStates.standing;                        
                    }
                    else
                    {
                        if (_outPutNodes.Count>0)
                        {
                            _PlayerStandingNode = _outPutNodes[TimePerIndex()];
                        }
                    }
                    break;
                case PlayerStates.standing:
                    break;
                case PlayerStates.attacking:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 이동관련 타이머 모두 초기화
        /// </summary>
        public void ResetMoveTimers()
        {
            moveTargetTime = _outPutNodes.Count > 0 ? _outPutNodes.Count * (1f / playerStat.moveSpeed): 0;
            movingTimer = 0;
        }
        /// <summary>
        /// 초당 플레이어 이동속도를 기준으로 하여 Index를 반환
        /// </summary>
        /// <returns></returns>
        private int TimePerIndex()
        {
            return (int)(movingTimer / (1f / playerStat.moveSpeed));
        }
/*        IEnumerator MoveNode()
        {
            yield return null;
            float timer = 1f / playerStat.moveSpeed;
            while (_outPutNodes.Count > 0)
            {

            }
            for (int i = 0; i < _outPutNodes.Count; i++)
            {
                NodeBase tempNextNode = _outPutNodes[TimePerIndex()];
                Vector3 tempOrinPos = _playerNodeBase.transform.position;
                StartCoroutine(MoveAction(tempOrinPos, tempNextNode.transform.position, timer, 15f));
                yield return new WaitForSeconds(timer);
                MovePlayer(tempNextNode);
            }

        }
        IEnumerator MoveAction(Vector3 startPos,Vector3 endPos,float playerSpeedPerSec,float frame)
        {
            //이건 DOTween으로 처리하는게 나아보임
            _spawnedPlayer.transform.position = startPos;
            float moveFrame = playerSpeedPerSec / frame;
            //_spawnedPlayer.transform.position = startPos;
            for (int i = 0; i < frame; i++)
            {
                yield return new WaitForSeconds(moveFrame);
                Vector3 whereTo = endPos - startPos;
                whereTo = whereTo / frame;
                _spawnedPlayer.transform.position = startPos+(whereTo*i);
            }
            _spawnedPlayer.transform.position = endPos;
            //_spawnedPlayer.transform.position = endPos;
        }*/
    }
}
enum PlayerStates
{
    walking,standing,attacking
}