using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerHammer : MonoBehaviour
{
    public float force ;
    private GameObject hitObject;

    private void Update()
    {
        force = this.GetComponentInParent<ReadoutPhysics>().currentForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        hitObject = other.gameObject;

        if(hitObject.tag == "Ingot")
        {
            HandleInput(hitObject);
        }
    }

    void HandleInput(GameObject hitObject)
    {
        //Ray inputRay = camera.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(inputRay, out hit))
        //{
        MeshDeformer deformer = hitObject.GetComponent<MeshDeformer>();

        //    if (deformer)
        //    {

        Vector3 point = transform.position;
        //point += hit.normal * forceOffset;
        deformer.AddDeformingForce(point, force);

        //    }
        //}
    }
}
