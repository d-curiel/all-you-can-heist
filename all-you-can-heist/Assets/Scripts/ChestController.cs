using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : CollectableController
{
    [SerializeField]
    LootingData looting;
    Animator m_Animator;
    bool m_IsLooted;
    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        
    }

    override
    public LootingData Loot()
    {
        if (!m_IsLooted)
        {
            m_Animator.SetBool("Open", true);
            m_IsLooted = true;
            return looting;
        }
        return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !m_IsLooted)
        {
            foreach(Transform child in transform)
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
