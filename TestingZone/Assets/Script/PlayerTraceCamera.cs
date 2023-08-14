using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTraceCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform plrTR;
    public Vector3 cameraDistance;
    private void Reset()
    {
        plrTR = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = plrTR.position + cameraDistance;
    }
}
