using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RightClickCameraMovement : MonoBehaviour
{
    void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }
 
    public float GetAxisCustom(string axisName)
    {
        if(axisName == "Mouse X")
        {
            if (Input.GetKey("mouse 1"))
            {
                return UnityEngine.Input.GetAxis("Mouse X");
            } 
            else
            {
                return 0;
            }
        }
        else if (axisName == "Mouse Y")
        {
            if (Input.GetKey("mouse 1"))
            {
                return UnityEngine.Input.GetAxis("Mouse Y");
            } else
            {
                return 0;
            }
        }
        return UnityEngine.Input.GetAxis(axisName);
    }
}
