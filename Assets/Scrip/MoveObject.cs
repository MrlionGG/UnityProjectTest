using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    RaycastHit hit;
    public GameObject dragObject;
    public LayerMask dragLayer;
    public string dragTag;
    public LayerMask planeLayer;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {
            if (hit.collider.CompareTag(dragTag) && Input.GetKeyDown(KeyCode.Mouse1))
            {
                dragObject = hit.collider.gameObject;
            }
        }
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, planeLayer))
        {
            if (Input.GetKey(KeyCode.Mouse1) && dragObject)
            {
                dragObject.transform.position = hit.point;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            dragObject = null;
        }
        /*if (Physics.Raycast(pc.conditions[i].conditionObject.position, pc.conditions[i].conditionObject.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, dragLayer)) 
        { 
            if (Vector3.Distance(hit.point, pc.conditions[i].positions) < 1f) 
            { count++; } 
        }*/
    }
}
