using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallBTester : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TestOBJ;
    public System.Action Actor;
    void Start()
    {
        cbLoger();
        Actor = null;
    }
    public void Evneter()
    {
        Debug.Log("�׼�");
    }
    private void CallBacker(System.Action A,System.Action<GameObject> OBJ_A = null)//�߰� �ݹ��Լ�
    {

        A = Actor;// ����+? ���� ���ǹ� = if(���� != null)
        A += Evneter;//action A�� Evneter �Լ��� �������
        Debug.Log(Actor);
        A?.Invoke();//��ȯ�� �ڷ����� ����
        Debug.Log("�ݹ��Լ� �߰�");
        OBJ_A?.Invoke(TestOBJ);//��ȯ�� �ڷ����� ����
    }
    private void cbLoger()
    {
        //�ݹ� �Լ��� ���ٽ����� ȣ���Ѵ�,�̋� (�Ű�����) => {����� ����}
        //���⼭ �Ű������� �ݹ� �Լ��� invoke(��ȣ�� ����)�� �״�� �����ؿ´�.
        CallBacker(() => { Debug.Log("�ݹ�"); }, (onetwoThree) => { Debug.Log(onetwoThree); });
    }

}
