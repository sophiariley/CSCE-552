using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (DetectionCircle))]
public class DetectionCircleVisualizer : Editor
{
    void OnSceneGUI() {
        DetectionCircle circle = (DetectionCircle)target;
        Handles.color = Color.red;
        Vector3 viewingAngleA = circle.DirectionOfVision (-circle.visionAngle / 2);
        Vector3 viewingAngleB = circle.DirectionOfVision (circle.visionAngle / 2);

        Handles.DrawWireArc(circle.transform.position, Vector3.up, viewingAngleA, circle.visionAngle, circle.visionRadius);
        Handles.DrawLine (circle.transform.position, circle.transform.position + viewingAngleA * circle.visionRadius);
        Handles.DrawLine (circle.transform.position, circle.transform.position + viewingAngleB * circle.visionRadius);
    
    }
}
