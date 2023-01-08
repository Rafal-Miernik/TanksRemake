using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ProjectileLauncher))]
public class AIController : MonoBehaviour
{
    [SerializeField] private float _wanderRadius;
    private NavMeshAgent _agent;
    private ProjectileLauncher _projectileLauncher;

    private void Awake()
    {
        _projectileLauncher = GetComponent<ProjectileLauncher>();
        _agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        GoToRandomLocation();
        InvokeRepeating("Shooting", Random.Range(1f, 4f), Random.Range(2f, 4f));
    }

    private void Update()
    {
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    GoToRandomLocation();
                }
            }
        }

    }

    private void GoToRandomLocation()
    {
        _agent.SetDestination(RandomNavmeshLocation(_wanderRadius));
    }

    private void Shooting()
    {
        _projectileLauncher.Shoot();
    }

    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius + transform.position;
        NavMeshHit hit;
        return NavMesh.SamplePosition(randomDirection, out hit, radius, 1) ? hit.position : Vector3.zero;
    }

}
