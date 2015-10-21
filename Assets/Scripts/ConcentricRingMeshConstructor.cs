using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConcentricRingMeshConstructor : MonoBehaviour {

    public int Rings = 10;

    private float RingThickness = 0.1f;

    private int resolution = 360;
    
    void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        Vector3[] vertices = new Vector3[resolution];
        List<int> triangles = new List<int>();



        for (int i = 0; i < resolution; i+=2)
        {
            Vector3 vector = Quaternion.Euler(0, i * (360 / resolution), 0) * Vector3.forward;
            vertices[i]     = vector;
            vertices[i + 1] = vector + (vector.normalized * RingThickness);
            
            triangles.AddRange(new int[] {
                i, (i+1) % resolution, (i+3) % resolution,
                i, (i+3) % resolution, (i+2) % resolution
            });
        }
        

        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();


    }

    void Update()
    {
    }
}
