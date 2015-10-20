using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform Transform;
    public Vector3 Target = Vector3.zero;

    public float dx = 5;
    public float dy = 5;

    [Range(0, 180)]
    public float ymin = 0;
    [Range(0, 180)]
    public float ymax = 180;

    void Start()
    {
    }

    void LateUpdate()
    {
        if (Transform && Input.GetMouseButton(0))
        {
            float x, y;

            // Rotate Horizontal
            x = Input.GetAxis("Mouse X") * dx;
            Transform.RotateAround(Target, Vector3.up, x);

            // Rotate Vertical
            
            Vector3 r = Transform.position - Target;    // The line from the target to the transform
            float theta = Vector3.Angle(r, Vector3.up); // The angle to the vertical axis

            y = -1 * Input.GetAxis("Mouse Y") * dy;

            if (theta - y > ymin && theta - y < ymax)
            {
                Transform.RotateAround(Target, Vector3.Cross(r, Vector3.up), y);
            }
        }
    }
}