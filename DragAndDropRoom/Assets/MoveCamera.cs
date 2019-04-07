using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public int UpDownMaxScroll;
    public int LeftRightMaxScroll;

    public int MinZoom;
    public int MaxZoom;
    
    public int ScrollSpeed;
    public int ZoomSpeed;

    public int MinPitch;
    public int MaxPitch;

    // Update is called once per frame
    void Update()
    {
        /// KEYBOARD AND EDGE SCROLLING ///
        /// 
        // If mouse detected at the top of the screen
        if ((Input.mousePosition.y >= Screen.height || Input.GetKey("up")) && Camera.main.gameObject.transform.position.z < UpDownMaxScroll)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
        }

        // If mouse detected at the bottom of the screen
        if ((Input.mousePosition.y <= 0 || Input.GetKey("down")) && Camera.main.gameObject.transform.position.z > -UpDownMaxScroll)
        {
            transform.Translate(Vector3.back * Time.deltaTime * ScrollSpeed, Space.World);
        }
        
        // If mouse detected at the right of the screen
        if ((Input.mousePosition.x >= Screen.width || Input.GetKey("right")) && Camera.main.gameObject.transform.position.x < LeftRightMaxScroll)
        {
            transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
        }
        
        // If mouse detected at the left of the screen
        if ((Input.mousePosition.x <= 0 || Input.GetKey("left")) && Camera.main.gameObject.transform.position.x > -LeftRightMaxScroll)
        {
            transform.Translate(Vector3.left * Time.deltaTime * ScrollSpeed, Space.World);
        }

        /// KEYBOARD AND MOUSE WHEEL SCROLLING ///
        /// 
        // Zoom in
        if (((Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey("=")) && Camera.main.gameObject.transform.position.y > MinZoom) && !Input.GetMouseButton(2))
        {
            transform.Translate(Vector3.down * Time.deltaTime * ZoomSpeed, Space.World);
        }

        //Zoom out
        if (((Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey("-")) && Camera.main.gameObject.transform.position.y < MaxZoom) && !Input.GetMouseButton(2))
        {
            transform.Translate(Vector3.up * Time.deltaTime * ZoomSpeed, Space.World);
        }

        /// KEYBOARD AND MOUSE BUTTON PITCH ///
        /// 
        // Pitch down
        if ((Input.GetMouseButton(1) && Input.GetAxis("Mouse Y") < 0) || Input.GetKey("p"))
        {
            if (Camera.main.gameObject.transform.rotation.x <= 35)
            {
                Debug.Log("Min");
                transform.Rotate(Vector3.right * Time.deltaTime * ZoomSpeed, Space.World);
            }
        }

        // Pitch up
        if ((Input.GetMouseButton(1) && Input.GetAxis("Mouse Y") > 0) || Input.GetKey("o"))
        {
            if (Camera.main.gameObject.transform.rotation.x <= 90)
            {
                Debug.Log("Max");
                transform.Rotate(Vector3.left * Time.deltaTime * ZoomSpeed, Space.World);
            }
        }

        /// KEYBOARD AND MOUSE BUTTON ROTATION ///
        /// 
        // Rotate right
        if (Input.GetMouseButton(2) && Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * ZoomSpeed * 2, Space.World);
        }

        // Rotate left
        if (Input.GetMouseButton(2) && Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(Vector3.down * Time.deltaTime * ZoomSpeed * 2, Space.World);
        }

    }
}
