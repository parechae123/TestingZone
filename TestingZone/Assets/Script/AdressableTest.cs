using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;

public class AdressableTest : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject dd;
    private GameObject RefTester;
    [SerializeField] private IResourceLocation ss;

    //AssetReference+��巹������ ����ϴ� �ڷ��� �������� �����Ǿ� ����
    //https://www.youtube.com/watch?v=Z84GCeod_BM �ش� ������ ���� ������
    void Start()
    {
        /*dd = dd.LoadAsset<GameObject>();*/
        
        Addressables.InstantiateAsync(ss,null,false,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
