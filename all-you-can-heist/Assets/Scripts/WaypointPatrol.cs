using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class WaypointPatrol : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent m_NavMeshAgent;

    int m_CurrentWaypointIndex;

    [SerializeField]
    Transform[] waypoints;

    private void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        m_NavMeshAgent.SetDestination(waypoints[0].position);
    }

    void FixedUpdate()
    {
        if (m_NavMeshAgent.remainingDistance <= m_NavMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            m_NavMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
