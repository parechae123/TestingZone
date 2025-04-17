using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CodeTestRemind : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField]Transform arrowTR;
    [SerializeField]Vector3 mousePos;
    void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 playerCamPos = Camera.main.WorldToScreenPoint(transform.position);

            Vector2 mouseDir = mousePos;
            Vector2 playerDir = playerCamPos;
            Vector2 pos = playerDir- mouseDir;

            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            //¾Æ Àý´ñ°ª...
            Debug.Log($"Angle: {angle}");
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }

}
