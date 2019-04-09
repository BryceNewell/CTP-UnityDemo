using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    
    GameObject[] hammers;
    GameObject[] ingots;
    public DeformationType deformationType;
    public ElasticProperties elastic = ElasticProperties.No;
    [Tooltip("Material softness, between 100 - 1000.")]
    public float materialSoftness = 500;
    [Tooltip("Distance from main impact, between 1 - 20.")]
    public float deformationArea = 5;


	void Start ()
    {
        hammers = GameObject.FindGameObjectsWithTag("Hammer");
        ingots = GameObject.FindGameObjectsWithTag("Ingot");
	}

	void Update ()
    {
        UpdateHammersType();
        UpdateIngots();
	}

    private void UpdateHammersType()
    {
        foreach(GameObject hammer in hammers)
        {
            hammer.GetComponentInChildren<MeshDeformerHammer>().SetDeformationType(deformationType);
        }
    }

    private void UpdateIngots()
    {
        foreach(GameObject ingot in ingots)
        {
            ingot.GetComponent<MeshDeformer>().SetForceMultiplier(materialSoftness);
            ingot.GetComponent<MeshDeformer>().SetAreaOfEffect(deformationArea);
            ingot.GetComponent<MeshDeformer>().elastic = elastic;
        }
    }
}
