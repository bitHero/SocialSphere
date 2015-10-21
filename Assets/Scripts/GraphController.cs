using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraphController : MonoBehaviour {

    [Range(1,100)]
    public int VertexCount = 10;

    private GameObject graphVertex;
    private GameObject graphEdge;

    private List<GameObject> Vertices, Edges;

    // Use this for initialization
    void Start ()
    {
        Vertices = new List<GameObject>(VertexCount);
        Edges = new List<GameObject>(VertexCount - 1);

        graphVertex = Resources.Load<GameObject>("GraphVertex");
        graphEdge = Resources.Load<GameObject>("GraphEdge");
        Vector3 move = Vector3.zero;
        for (int i = 0; i < VertexCount; i++)
        {
            var vertex = Instantiate(graphVertex);
            vertex.transform.SetParent(this.transform);
            Vertices.Add(vertex);

            vertex.transform.Translate(move);
            move.x += Random.Range(1f, 5f);
            move.y += Random.Range(1f, 2f);

            if(i > 0)
            {
                var edge = Instantiate(graphEdge);
                edge.transform.SetParent(this.transform);
                Edges.Add(edge);

                var lastVertex = Vertices[i - 1];

                edge.transform.position = (lastVertex.transform.position + vertex.transform.position) / 2f;
                edge.transform.up = lastVertex.transform.position - vertex.transform.position;
                edge.transform.localScale = new Vector3(
                    edge.transform.localScale.x,
                    Vector3.Distance(lastVertex.transform.position, vertex.transform.position)/2,
                    edge.transform.localScale.z
                    );
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
