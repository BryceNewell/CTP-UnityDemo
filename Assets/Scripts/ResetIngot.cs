using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIngot : MonoBehaviour
{
    public GameObject ingot;
    public GameObject ingotToSpawn;
    public GameObject hammerToSpawn;
    public GameObject wallHammer1;
    public GameObject wallHammer2;
    public Vector3 spawnLocation;
    public Vector3 hammerPos1;
    public Vector3 hammerPos2;


    private void Start()
    {
        hammerPos1 = wallHammer1.transform.position;
        hammerPos2 = wallHammer2.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hammer")
        {
            Destroy(ingot);
            ingot = Instantiate(ingotToSpawn);
            ingot.transform.position = spawnLocation;

            ingot = Instantiate(ingotToSpawn);

            GameObject hammer1 = Instantiate(hammerToSpawn);
            hammer1.transform.position = hammerPos1;
            GameObject hammer2 = Instantiate(hammerToSpawn);
            hammer2.transform.position = hammerPos2;

        }
    }
}
