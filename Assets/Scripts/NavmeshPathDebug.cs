using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshPathDebug : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agentToDebug;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(_agentToDebug.hasPath)
        {
            _lineRenderer.positionCount = _agentToDebug.path.corners.Length;
            _lineRenderer.SetPositions(_agentToDebug.path.corners);
            _lineRenderer.enabled = true;

        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
}
