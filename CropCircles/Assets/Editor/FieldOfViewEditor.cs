using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


//Editor script needs to be within 'Editor' folder for it to work
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        
        //enemy  sphere
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.DetectionRadius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.angle / 2);

        //fov of enemy
        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.DetectionRadius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.DetectionRadius);
        
        //can see player
        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position, fov.playerRef.transform.position);
        }
    }

    //Math calculation for angles
    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
