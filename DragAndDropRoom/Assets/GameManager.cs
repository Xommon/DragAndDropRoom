using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selected;
    Ray ray;
    RaycastHit hit;

    public bool validPlacement;

    void Start()
    {
        // Start with no object selected
        selected = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Select and deselect and object
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

        // Make selected object obvious
        if (selected != null)
        {
            selected.transform.position = Input.mousePosition;
        }
    }
}
