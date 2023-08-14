using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    // Update is called once per frame
    public Vector3 targetPosition;
    private Ray cameraRay;
    private RaycastHit cameraHit;
    public LayerMask ground;
    public float MoveSpeed;
    public Vector3 halfPlayerHeight;
    public NavMeshAgent NA;
    private void Reset()
    {
        halfPlayerHeight = new Vector3(0, GetComponent<Collider>().bounds.extents.y, 0);
        NA = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(cameraRay,out cameraHit, float.PositiveInfinity, ground);
            targetPosition = cameraHit.point;
            NA.SetDestination(cameraHit.point);
        }
    }
}
