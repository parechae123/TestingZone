using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QueueTester : MonoBehaviour
{
    [SerializeField]public TempleteStudyQueue<GameObject> TestQueue = new TempleteStudyQueue<GameObject>();
    [SerializeField]public TempleteStudyQueue<string> TestStringQueue = new TempleteStudyQueue<string>();
    public GameObject Prefab;
    public int times;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            for (int i = 0; i < times; i++)
            {
                string tempText = TestStringQueue.Lenght.ToString();
                TestStringQueue.enqueue(tempText);

/*                GameObject temp = new GameObject(TestQueue.Lenght.ToString());
                temp.SetActive(false);
                TestQueue.enqueue(temp);*/
            }

        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            for (int i = 0; i < times; i++)
            {
                Debug.LogError(TestStringQueue.Dequeue());


/*                GameObject tempGOBJ = TestQueue.Dequeue();
                tempGOBJ.SetActive(true);
                Debug.Log(tempGOBJ.name);*/

            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            TestStringQueue.Clear();
        }
    }
}
