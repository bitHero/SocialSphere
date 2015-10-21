using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform Camera;
    public Vector3 Target = Vector3.zero;

    public float dx = 5;
    public float dy = 5;
    public float dr = 1;

    [Range(0, 180)]
    public float ymin = 0;
    [Range(0, 180)]
    public float ymax = 180;
    
    public float zmin = 1;
    public float zmax = 10;

    void Start()
    {
    }

    void LateUpdate()
    {
        if (!Camera)
        {
            Debug.LogError("No Camera selected for controller");
            return;
        }

        // Handle Pan
        if (Input.GetMouseButton(0))
        {
            float x, y;

            // Rotate Horizontal
            x = Input.GetAxis("Mouse X") * dx;
            Camera.RotateAround(Target, Vector3.up, x);

            // Rotate Vertical
            Vector3 r = Camera.position - Target;    // The line from the target to the transform
            float theta = Vector3.Angle(r, Vector3.up); // The angle to the vertical axis

            y = -1 * Input.GetAxis("Mouse Y") * dy;

            if (theta - y > ymin && theta - y < ymax)
            {
                Camera.RotateAround(Target, Vector3.Cross(r, Vector3.up), y);
            }
        }

        //Handle Scroll
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 r = Camera.position - Target;
            Vector3 z = r * scroll * dr * -1;
            if ((r + z).magnitude > zmin && (r + z).magnitude < zmax)
            {
                Camera.Translate(z, Space.World);
            }
        }
    }
}