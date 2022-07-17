using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    Transform m_PlayerPosition;
    bool m_IsPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            m_IsPlayerInRange = true;
            m_PlayerPosition = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            m_IsPlayerInRange = false;
        }
    }
    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = m_PlayerPosition.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction, Color.green);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log("tag: " + raycastHit.collider.gameObject.tag);
                Debug.Log("tag: " + raycastHit.collider);
                Debug.Log("tag 2: " + raycastHit.transform.tag);
                Debug.Log("compare: " + raycastHit.collider.gameObject.CompareTag("Player"));
                if (raycastHit.collider.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Player Caught");
                }
            }
        }
    }
}
