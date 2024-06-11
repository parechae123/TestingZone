using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSR : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        MainDictionary.Instance.AddDictionary(transform.position, gameObject.GetComponent<SpriteRenderer>());
        Debug.Log(MainDictionary.Instance.sprites.Count);
    }
}
