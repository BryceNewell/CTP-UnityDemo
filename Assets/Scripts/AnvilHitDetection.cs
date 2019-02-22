using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHitDetection : MonoBehaviour
{
    public float measuredSpeed;
    public float measuredForce;

    private void OnTriggerEnter(Collider other)
    {
        //measuredSpeed = other.GetComponent<ReadoutPhysics>().currentSpeed;
        //measuredForce = other.GetComponent<ReadoutPhysics>().currentForce;
    }
}
