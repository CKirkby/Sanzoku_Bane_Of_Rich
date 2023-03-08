using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PirateFOV))]

public class FOVEditor : Editor
{
    private void OnSceneGUI()
    {
        PirateFOV fov = (PirateFOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.castPoint.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.castPoint.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.castPoint.transform.eulerAngles.y, fov.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.castPoint.transform.position, fov.castPoint.transform.position + viewAngle01 * fov.radius);
        Handles.DrawLine(fov.castPoint.transform.position, fov.castPoint.transform.position + viewAngle02 * fov.radius);

        if (fov.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.castPoint.transform.position, fov.playerRef.transform.position);
        }

    }

    private Vector3 DirectionFromAngle(float eurlerY, float angleInDegrees)
    {
        angleInDegrees += eurlerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }




}
