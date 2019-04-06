using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MetalType
{
    Iron,
};

public class OreToIngot : MonoBehaviour
{
    public GameObject ironIngot;
    private MetalType metalType;
    private GameObject ingot;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ore")
        {
            CheckOre(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void CheckOre(GameObject ore)
    {
        if (ore.GetComponent<Ore>().metalType == MetalType.Iron)
        {
            ingot = Instantiate(ironIngot);
            ingot.transform.position = ore.transform.position;
        }
    }
}
