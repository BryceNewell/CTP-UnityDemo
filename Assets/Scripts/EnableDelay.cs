using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDelay : MonoBehaviour
{
    public float delayTime = 2;
    public GameObject ClothActor;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Delay(delayTime));
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        ClothActor.SetActive(true);
    }
}
