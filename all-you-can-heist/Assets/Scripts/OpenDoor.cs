using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    [SerializeField]
    bool requireKey;
   
    public void Open()
    {
        animator.SetBool("OpenDoor", true);
    }

    public bool RequireKey { get; set; }
}
