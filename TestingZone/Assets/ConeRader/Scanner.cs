using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    LinkedList<SpriteRenderer> renderers;
    public float halfAngle;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            renderers = GetConeRegion(transform.position, halfAngle, distance);
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log(renderers.Count);
            ResetDic();
        }
    }
    private LinkedList<SpriteRenderer> GetConeRegion(Vector3 position, float halfAngle, float distance)
    {
        LinkedList<SpriteRenderer> OutputBlocks = new LinkedList<SpriteRenderer>();
        foreach (KeyValuePair<Vector2,SpriteRenderer> item in MainDictionary.Instance.sprites)
        {
            Vector3 dataPosition = item.Key;
            Vector3 toData = dataPosition - position;

            // �Ÿ� �˻�
            if (toData.magnitude <= distance)
            {
                // ������Ʈ - �÷��̾� = �÷��̾�κ��� ������Ʈ�� �󸶳� ������ �ִ°�
                Debug.LogError(toData.magnitude);
                // ���� �˻�
                float angleToData = Vector2.Angle(Vector2.down, toData);
                Debug.Log(angleToData);
                if (angleToData <= halfAngle)
                {
                    item.Value.color = Color.black;
                    OutputBlocks.AddLast(item.Value);
                    
                }
            }
        }
        return OutputBlocks;
    }
    private void ResetDic()
    {
        foreach (var item in MainDictionary.Instance.sprites)
        {
            item.Value.color = Color.white;
        }
    }
}
