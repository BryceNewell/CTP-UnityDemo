using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIngot : MonoBehaviour
{
    public GameObject ingot;
    public GameObject ingotToSpawn;
    public Vector3 spawnLocation;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hammer")
        {
            Destroy(ingot);
            ingot = Instantiate(ingotToSpawn);
            ingot.transform.position = spawnLocation;
        }
    }
}
