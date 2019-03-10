using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDeformer : MonoBehaviour
{
    public enum ElasticProperties { Yes, No };
    public ElasticProperties elastic;
    public float springForce = 20f;
    public float damping = 5f;
    public float forceMultiplier = 100;

    private Mesh deformingMesh;
    private Vector3[] originalVertices;
    private Vector3[] displacedVertices;
    private Vector3[] vertexVelocities;
    private float uniformScale = 1f;
    private MeshCollider collider;
    private bool updateMeshCollider;

    void Start()
    {
        deformingMesh = GetComponent<MeshFilter>().mesh;
        originalVertices = deformingMesh.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        collider = GetComponent<MeshCollider>();

        for (int i = 0; i < originalVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i];
        }
        vertexVelocities = new Vector3[originalVertices.Length];
    }

    private void Update()
    {
        if(!collider.sharedMesh)
        {
            collider.sharedMesh = deformingMesh;
        }

        for (int i=0; i < displacedVertices.Length; i++)
        {
            UpdateVertex(i);
        }
        deformingMesh.vertices = displacedVertices;
        deformingMesh.RecalculateNormals();
        if(updateMeshCollider)
        {
            deformingMesh = GetComponent<MeshFilter>().mesh;
            collider.sharedMesh = deformingMesh;
            updateMeshCollider = false;
        }
    }

    void UpdateVertex(int i)
    {
        Vector3 velocity = vertexVelocities[i];
        Vector3 displacement = displacedVertices[i] - originalVertices[i];
        displacement *= uniformScale;
        switch (elastic)
        {
            case ElasticProperties.Yes:
            {
                velocity -= displacement * springForce * Time.deltaTime;
                break;
            }
        }
        velocity *= 1f - damping * Time.deltaTime;
        vertexVelocities[i] = velocity;
        displacedVertices[i] += velocity * Time.deltaTime;
    }

    public void AddDeformingForce (Vector3 point, float force)
    {
        point = transform.InverseTransformPoint(point);
        for (int i = 0; i < displacedVertices.Length; i++)
        {
            AddForceToVertex(i, point, force);
        }
        updateMeshCollider = true;
    }

    void AddForceToVertex(int i, Vector3 point, float force)
    {
        Vector3 pointToVertex = displacedVertices[i] - point;
        //strength curve from point of contact (look up curve with a graph calc)
        float attenuatedForce = ((force * forceMultiplier) / (1f + (pointToVertex.sqrMagnitude *10)));
        float velocity = attenuatedForce * Time.deltaTime;
        vertexVelocities[i] += pointToVertex.normalized * velocity;
    }
}
