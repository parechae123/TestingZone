using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    // Update is called once per frame
    private Ray cameraRay;
    private RaycastHit cameraHit;
    public LayerMask ground;
    public Vector3 halfPlayerHeight;
    public NavMeshAgent NA;
    public float MoveSpeed;
    private void Reset()
    {
        halfPlayerHeight = new Vector3(0, GetComponent<Collider>().bounds.extents.y, 0);
        NA = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        RefTester(ref MoveSpeed);
    }
    private void RefTester(ref float aa)
    {
        NA.speed = aa;
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(cameraRay,out cameraHit, float.PositiveInfinity, ground);
            NA.SetDestination(cameraHit.point);
        }
    }
}
