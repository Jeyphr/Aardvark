using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class gs_pathing : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] public Transform Target;
    private NavMeshAgent Agent;

    [Header("Statistics")]
    [SerializeField] public float updateSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(FollowTarget());

    }

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(updateSpeed);
        while (enabled) {
            Agent.SetDestination(Target.position);
            yield return Wait;
        }
    }
}

