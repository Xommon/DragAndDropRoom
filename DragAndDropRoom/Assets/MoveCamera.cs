using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public int MinZoom;
    public int MaxZoom;

    public float UpDownMaxScroll;
    public float LeftRightMaxScroll;

    public int ScrollSpeed;
    public int ZoomSpeed;

    // Update is called once per frame
    void Update()
    {
        /// KEYBOARD AND EDGE SCROLLING ///
        /// 
        // If mouse detected at the top of the screen
        if (Input.mousePosition.y >= Screen.height || Input.GetKey("up"))
        {
            if (Camera.main.gameObject.transform.position.z < UpDownMaxScroll)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
            }
        }

        // If mouse detected at the bottom of the screen
        if (Input.mousePosition.y <= 0 || Input.GetKey("down"))
        {
            if (Camera.main.gameObject.transform.position.z > -UpDownMaxScroll)
            {
                transform.Translate(Vector3.back * Time.deltaTime * ScrollSpeed, Space.World);
            }
        }
        
        // If mouse detected at the right of the screen
        if (Input.mousePosition.x >= Screen.width || Input.GetKey("right"))
        {
            if (Camera.main.gameObject.transform.position.x < LeftRightMaxScroll)
            {
                transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
            }
        }
        
        // If mouse detected at the left of the screen
        if (Input.mousePosition.x <= 0 || Input.GetKey("left"))
        {
            if (Camera.main.gameObject.transform.position.x > -LeftRightMaxScroll)
            {
                transform.Translate(Vector3.left * Time.deltaTime * ScrollSpeed, Space.World);
            }
        }

        /// KEYBOARD AND MOUSE WHEEL SCROLLING ///
        /// 
        // Zoom in
        if ((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey("=")) && Camera.main.gameObject.transform.position.y > MinZoom)
        {
            transform.Translate(Vector3.down * Time.deltaTime * ZoomSpeed, Space.World);
        }

        //Zoom out
        if ((Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey("-")) && Camera.main.gameObject.transform.position.y < MaxZoom)
        {
            transform.Translate(Vector3.up * Time.deltaTime * ZoomSpeed, Space.World);
        }
    }
}
