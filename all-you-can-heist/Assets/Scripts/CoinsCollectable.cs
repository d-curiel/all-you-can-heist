using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollectable : CollectableController
{

    [SerializeField]
    LootingData looting;

    bool m_IsLooted;
    [SerializeField]
    Material[] highlightMaterials;

    Material[] originalMaterials;
    MeshRenderer m_MeshRenderer;
    private void Awake()
    {
        m_MeshRenderer = gameObject.GetComponent<MeshRenderer>();
        originalMaterials = m_MeshRenderer.materials;
    }

    override
    public LootingData Loot()
    {
        if (!m_IsLooted)
        {
            m_IsLooted = true;
            this.gameObject.SetActive(false);
            return looting;
        }
        return null;
    }
    public void OnTriggerEnter()
    {
        m_MeshRenderer.materials = highlightMaterials;
    }
    public void OnTriggerExit()
    {
        m_MeshRenderer.materials = originalMaterials;
    }
}
