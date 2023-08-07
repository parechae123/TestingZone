using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBTester : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TestOBJ;
    void Start()
    {
        cbLoger();
    }
    public void Evneter()
    {
        Debug.Log("액션");
    }
    private void CallBacker(System.Action A,System.Action<GameObject> OBJ_A = null)//야가 콜백함수
    {
        A = null;// 변수+? 식의 조건문 = if(변수 != null)
        A += Evneter;//action A에 Evneter 함수를 등록해줌
        A?.Invoke();//반환할 자료형이 없음

        Debug.Log("콜백함수 중간");
        OBJ_A?.Invoke(TestOBJ);//반환할 자료형이 있음
    }
    private void cbLoger()
    {
        //콜백 함수를 람다식으로 호출한다,이떄 (매개변수) => {실행될 내용}
        //여기서 매개변수는 콜백 함수의 invoke(괄호안 여기)를 그대로 참조해온다.
        CallBacker(() => { Debug.Log("콜백"); }, (_) => { Debug.Log(_); });
    }

}
