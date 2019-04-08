using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerHammer : MonoBehaviour
{
    public float force ;
    private GameObject hitObject;
    public float forceOffset = 0.1f;
    public float distanceFromIngot;
    public float deformDistance = 0.3f;
    private float hitTimer = 0.0f;
    public float timeBetweenHits = 0.5f;

    private void Update()
    {
        force = this.GetComponentInParent<ReadoutPhysics>().currentForce;
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit))
        {

            if (hit.distance < deformDistance/* && hitTimer > timeBetweenHits*/)
            {
                HandleInput(hit.transform.gameObject, hit);
            }
        }
        hitTimer += Time.deltaTime;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
    }

    void HandleInput(GameObject hitObject, RaycastHit hit)
    {
        MeshDeformer deformer = hitObject.GetComponent<MeshDeformer>();

        if (deformer)
        {
            //Debug.Log("Distance from hit: " + hit.distance);
            //Debug.Log("Location of hit: " + hit.transform.position);
            Debug.Log(force);
            Vector3 point = hit.point;
            point += hit.normal * forceOffset;
            deformer.AddDeformingForce(point, force);
        }
    }
}
