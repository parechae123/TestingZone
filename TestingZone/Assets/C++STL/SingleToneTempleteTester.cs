using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingleToneTempleteTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MySingleton<int>.GetSingleton();
            MySingleton<float>.GetSingleton();

        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            MySingleton<int>.Release();
            MySingleton<float>.Release();
            MySingleton<byte>.Release();
            Debug.Log(MySingleton<int>.ReturnValueInParent() + "인트밸류\n" + MySingleton<float>.ReturnValueInParent() + "플로트 밸류\n" + MySingleton<byte>.ReturnValueInParent() + "바이트 밸류\n");

        }
        else if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            MySingleton<int>.AddValueInParent(10);
            MySingleton<float>.AddValueInParent(20.5f);
            MySingleton<byte>.AddValueInParent(20);
            Debug.Log(MySingleton<int>.ReturnValueInParent() + "인트밸류\n" + MySingleton<float>.ReturnValueInParent() + "플로트 밸류\n" + MySingleton<byte>.ReturnValueInParent() + "바이트 밸류\n");

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(MySingletonInt.IsItIntOnly());
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log(MySingletonInt.ReturnValueInParent());
            Debug.Log(MySingleton<int>.ReturnValueInParent());
            //상속받은애도 같은 공간을 쓰는것이 드러남
        }
    }
}
