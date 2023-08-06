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

    //AssetReference+어드레서블을 사용하는 자료형 형식으로 구성되어 있음
    //https://www.youtube.com/watch?v=Z84GCeod_BM 해당 공략을 보고 공부함
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
