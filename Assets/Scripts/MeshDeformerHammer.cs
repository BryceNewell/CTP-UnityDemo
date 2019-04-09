using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeformationType
{
    CollisionBased,
    RaycastBased
};

public class MeshDeformerHammer : MonoBehaviour
{
    private float force ;
    private GameObject hitObject;
    private float forceOffset = 0.1f;
    private float distanceFromIngot;
    private float deformDistance = 0.3f;
    private float hitTimer = 0.0f;
    public float timeBetweenHits = 0.5f;
    public List<AudioClip> hitSounds = new List<AudioClip>();
    private AudioSource audioSource;
    public DeformationType deformationType;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        force = this.GetComponentInParent<ReadoutPhysics>().currentForce;

        if (deformationType == DeformationType.RaycastBased)
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(transform.position, fwd, out hit))
            {
                if (hit.distance < deformDistance)
                {
                    HandleInput(hit.transform.gameObject, hit);
                }
            }
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.yellow);
        }
        hitTimer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (deformationType == DeformationType.CollisionBased)
        {
            if (other.gameObject.tag == "Ingot" && hitTimer >= timeBetweenHits)
            {
                PassTriggerInput(other.gameObject, other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position));
                hitTimer = 0;
            }
        }
    }

    void PassTriggerInput(GameObject hitObject, Vector3 hitLocation)
    {
        MeshDeformer deformer = hitObject.GetComponent<MeshDeformer>();

        if (deformer)
        {
            Debug.Log("Force: " + force);
            Vector3 point = hitLocation;
            deformer.AddDeformingForce(point, force);
            audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Count)]);
        }
    }

    void HandleInput(GameObject hitObject, RaycastHit hit)
    {
        MeshDeformer deformer = hitObject.GetComponent<MeshDeformer>();

        if (deformer)
        {
            Debug.Log(force);
            Vector3 point = hit.point;
            point += hit.normal * forceOffset;
            deformer.AddDeformingForce(point, force);
            audioSource.PlayOneShot(hitSounds[Random.Range(0, hitSounds.Count)]);
        }
    }

    public void SetDeformationType(DeformationType type)
    {
        deformationType = type;
    }

}
