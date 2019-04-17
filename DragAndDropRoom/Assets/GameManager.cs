using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selected;
    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.gameObject.tag == "MoveableObject")
            {
                selected = hit.collider.gameObject;
                Debug.Log(selected.name);
            }
            else
            {
                selected = null;
                Debug.Log("no object");
            }
        }
    }
}
