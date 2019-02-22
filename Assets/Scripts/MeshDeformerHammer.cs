using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerHammer : MonoBehaviour
{
    public float force ;
    private GameObject hitObject;
    public float forceOffset = 0.1f;
    public float distanceFromIngot;

    private void Update()
    {
        force = this.GetComponentInParent<ReadoutPhysics>().currentForce * 0.01f;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit))
        {
            distanceFromIngot = Vector3.Distance(hit.transform.position, transform.position);
            Debug.Log(distanceFromIngot);
            if (distanceFromIngot < 0.36f )
            {
                if (hit.transform.gameObject.tag == "Ingot")
                {
                    HandleInput(hit.transform.gameObject, hit);
                    Debug.Log("Should Deform");
                }
            }
            Debug.Log("There is something in front of the object!");
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
    }

    void HandleInput(GameObject hitObject, RaycastHit hit)
    {
        MeshDeformer deformer = hitObject.GetComponent<MeshDeformer>();
        Vector3 point = hit.point;
        point += hit.normal * forceOffset;
        deformer.AddDeformingForce(point, force);
    }
}
