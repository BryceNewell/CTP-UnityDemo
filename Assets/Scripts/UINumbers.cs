using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINumbers : MonoBehaviour
{
    public Text currentHammerSpeed;
    public Text lastHitSpeed;
    public Text lastHitForce;
    public GameObject hammer;
    public GameObject anvil;

	// Use this for initialization
	void Start ()
    {
        hammer = GameObject.FindGameObjectWithTag("Hammer");
        anvil = GameObject.FindGameObjectWithTag("Anvil");
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentHammerSpeed.text = hammer.GetComponent<ReadoutPhysics>().currentSpeed.ToString();
        lastHitSpeed.text = anvil.GetComponent<AnvilHitDetection>().measuredSpeed.ToString();
        lastHitForce.text = anvil.GetComponent<AnvilHitDetection>().measuredForce.ToString();
	}
}
