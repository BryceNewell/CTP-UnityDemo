using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHitDetection : MonoBehaviour
{
    public float measuredSpeed;
    public float measuredForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ingot")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ingot")
        {
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
