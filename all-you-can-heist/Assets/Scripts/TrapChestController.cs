using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChestController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {

                child.gameObject.GetComponent<HiglightMaterials>().ChangeAllMaterials();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in transform)
            {

                child.gameObject.GetComponent<HiglightMaterials>().RestoreMaterials();
            }
        }

    }

}
