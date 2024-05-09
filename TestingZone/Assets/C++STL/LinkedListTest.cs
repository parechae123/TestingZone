using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LinkedListTest : MonoBehaviour
{
    LinkedList<Vector3> positions = new LinkedList<Vector3>();
    public Vector3 registTargetVector;
    public LineRenderer lineRenderer;
    public Button addButton;
    public Button removeForward;
    public Button removeBack;
    
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        addButton.onClick.AddListener(() =>
        {
            RegistVector();
        });
        removeForward.onClick.AddListener(() =>
        {
            RemoveVector(true);
        });
        removeBack.onClick.AddListener(() =>
        {
            RemoveVector(false);
        });
        
    }
    private void Update()
    {
        
    }
    public void RegistVector()
    {
        positions.AddLast(registTargetVector);
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray<Vector3>());

    }
    public void RemoveVector(bool isForward)
    {
        if (isForward)
        {
            positions.RemoveFirst();
        }
        else
        {
            positions.RemoveLast();
        }
        lineRenderer.positionCount = positions.Count;
    }
}
