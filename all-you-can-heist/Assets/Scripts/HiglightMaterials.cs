using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiglightMaterials : MonoBehaviour
{
    [SerializeField]
    Material[] highlightMaterials;

    Material[] originalMaterials;
    MeshRenderer m_MeshRenderer;
    private void Awake()
    {
        m_MeshRenderer = gameObject.GetComponent<MeshRenderer>();
        originalMaterials = m_MeshRenderer.materials;
        
    }

    
    public void RestoreMaterials()
    {


        m_MeshRenderer.materials = originalMaterials;
        
    }
    public void ChangeAllMaterials()
    {
        m_MeshRenderer.materials = highlightMaterials;
    }
}
