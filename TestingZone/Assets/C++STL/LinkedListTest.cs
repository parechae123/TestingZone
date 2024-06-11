using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class LinkedListTest : MonoBehaviour
{
    LinkedList<Vector3> positions = new LinkedList<Vector3>();
    public int targetIndex;
    public Vector3 registTargetVector;
    public LineRenderer lineRenderer;
    public Button addButton;
    public Button removeForward;
    public Button removeBack;
    public Button removeTarget;
    
    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Text tempText = addButton.transform.GetChild(0).GetComponent<Text>();
        tempText.text = "�迭 �߰���ư";
        tempText.resizeTextForBestFit = true;
        tempText.resizeTextMaxSize = 400;
        tempText = removeForward.transform.GetChild(0).GetComponent<Text>();
        tempText.text = "�տ� ����";
        tempText.resizeTextForBestFit = true;
        tempText.resizeTextMaxSize = 400;
        tempText = removeBack.transform.GetChild(0).GetComponent<Text>();
        tempText.text = "�ڿ� ����";
        tempText.resizeTextForBestFit = true;
        tempText.resizeTextMaxSize = 400;
        tempText = removeTarget.transform.GetChild(0).GetComponent<Text>();
        tempText.text = "Ÿ�� ����";
        tempText.resizeTextForBestFit = true;
        tempText.resizeTextMaxSize = 400;
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
        removeTarget.onClick.AddListener(() =>
        {
            TargetVectorRemove();
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
    public void TargetVectorRemove()
    {
        int positionLength = positions.Count;
        Vector3[] tempArray = positions.ToArray();
        positions.Clear();
        for (int i = 0; i < positionLength; i++)
        {
            if (targetIndex == i)
            {
                positions.AddLast(registTargetVector);
            }
            else
            {
                positions.AddLast(tempArray[i]);
            }
        }
        lineRenderer.SetPositions(positions.ToArray<Vector3>());
    }

}
