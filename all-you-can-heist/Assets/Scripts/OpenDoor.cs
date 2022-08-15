using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    [SerializeField]
    private bool m_RequireKey;

    private bool m_IsDoorOpen;
    Animator animator;

    private void Awake()
    {
        m_IsDoorOpen = false;
        animator = GetComponent<Animator>();
    }
   

    public bool Open()
    {
        if (!m_IsDoorOpen)
        {
            animator.SetBool("OpenDoor", true);
            m_IsDoorOpen = true;
        }

        return m_IsDoorOpen;
    }
       

    public bool RequireKey()
    {
        return m_RequireKey;
    }

    public bool IsOpen()
    {
        return m_IsDoorOpen;
    }

}
