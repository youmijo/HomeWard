using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    GameObject scanObject;
    public GameManager manager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = 1 << LayerMask.NameToLayer("Object");

            if (Physics.Raycast(ray, out hit, layerMask))
            {
                Debug.Log(hit.transform.gameObject.name);
                scanObject = hit.collider.gameObject;
                manager.Action(scanObject);
            }
            else scanObject = null;
        }
    }
}
