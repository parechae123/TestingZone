using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using Tarodev_Pathfinding._Scripts.Units;
using UnityEngine;
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
        private Unit _spawnedPlayer, _spawnedGoal;
        public Stack<NodeBase> _outPutNodes = new Stack<NodeBase>();

        void Awake() => Instance = this;

        private void Start() {
            Tiles = _scriptableGrid.GenerateGrid();
         
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(BlinkNodes());
            }
        }
        IEnumerator BlinkNodes()
        {
            yield return null;
            float timer = 1f / playerStat.moveSpeed;
            while (_outPutNodes.Count > 0)
            {
                NodeBase tempNextNode = _outPutNodes.Pop();
                Vector3 tempOrinPos = _playerNodeBase.transform.position;
                StartCoroutine(MoveAction(tempOrinPos,tempNextNode.transform.position,timer,60f));
                yield return new WaitForSeconds(timer);
                MovePlayer(tempNextNode);
            }
        }
        IEnumerator MoveAction(Vector3 startPos,Vector3 endPos,float playerSpeed,float frame)
        {
            //이건 DOTween으로 처리하는게 나아보임
            float moveFrame = playerSpeed / frame;
            _spawnedPlayer.transform.position = startPos;
            for (int i = 1; i < frame; i++)
            {
                yield return new WaitForSeconds(moveFrame);
                Vector3 whereTo = endPos - startPos;
                whereTo = whereTo / frame;
                //축이 엇나감
                _spawnedPlayer.transform.position = _spawnedPlayer.transform.position + whereTo;
            }

            
        }
    }
}