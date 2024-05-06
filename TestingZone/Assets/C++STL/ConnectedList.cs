using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConnectedList : MonoBehaviour
{
    // Start is called before the first frame update
    public int count = 0;
    public int Count
    {
        get 
        { 
            count++;
            return count;
        }
    }
    [SerializeField]public LinkedList<int> list = new LinkedList<int>();
    [SerializeField]public List<int> listView = new List<int>();
    [SerializeField]public LinkedListNode<int> tempNode;
    public int targetNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            list.AddLast(Count);
            listView = list.ToList<int>();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            list.AddFirst(Count);
            listView = list.ToList<int>();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            list.Remove(targetNumber);
            listView = list.ToList<int>();

        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            list.RemoveFirst();
            listView = list.ToList<int>();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            list.RemoveLast();
            listView = list.ToList<int>();
            //�̰� �׳� ��Ű Queue�ƴ�??;;;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            tempNode = list.Find(targetNumber);
            Debug.Log(tempNode.Value);
            Debug.Log(tempNode.List);
            listView = list.ToList<int>();
            //���� �����ִ°Ű����� JsonUtility dictionary wrapper ���ֵ�
            
        }
    }
}
