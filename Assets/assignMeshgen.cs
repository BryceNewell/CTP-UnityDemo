using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assignMeshgen : MonoBehaviour
{
    public float ScaleX = 0.2f;
    public float ScaleY = 0.2f;
    public float ScaleZ = 0.4f;
    public bool RecalculateNormals = false;

    private Vector3[] _baseVertices;
    private MeshFilter meshFilter;

    // Use this for initialization
    private void Start()
    {
        meshFilter = this.GetComponent<MeshFilter>();
    }
    public  void assignMesh (Mesh generatedMesh)
    {
        meshFilter.mesh = generatedMesh;
        
	}
    public void Update()
    {
        if (_baseVertices == null)
        {
            _baseVertices = meshFilter.mesh.vertices;
        }

        var vertices = new Vector3[_baseVertices.Length];

        for (var i = 0; i < meshFilter.mesh.vertices.Length; i++)
        {
            var vertex = _baseVertices[i];
            vertex.x = vertex.x * ScaleX;
            vertex.y = vertex.y * ScaleY;
            vertex.z = vertex.z * ScaleZ;
            vertices[i] = vertex;
        }

        meshFilter.mesh.vertices = vertices;

        if (RecalculateNormals)
        {
            meshFilter.mesh.RecalculateNormals();
        }
        meshFilter.mesh.RecalculateBounds();

    }

}
