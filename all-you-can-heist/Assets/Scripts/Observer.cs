using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    Transform m_PlayerPosition;
    bool m_IsPlayerInRange;
    [SerializeField]
    Transform m_KnigtPosition;

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
            Ray ray = new Ray(m_KnigtPosition.position, direction);
            //Debug.DrawRay(m_KnigtPosition.position, direction, Color.green);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.CompareTag("Player"))
                {
                    UIManager.Instance.LoseGame();
                }
            }
        }
    }
}
