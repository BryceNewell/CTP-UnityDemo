using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadoutPhysics : MonoBehaviour
{

    Rigidbody rb;
    public float mass;

    public float currentSpeed;
    public float currentAcceleration;
    public float currentForce;

	// Use this for initialization
	void Start ()
    {
        rb = this.gameObject.GetComponentInChildren<Rigidbody>();
        mass = rb.mass;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentSpeed = rb.velocity.magnitude;
        currentForce = mass * currentSpeed;
	}
}
