using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _pickUps;
    [SerializeField] private float _spawnRate;


    private void Start()
    {
        InvokeRepeating("SpawnPickUp", _spawnRate, _spawnRate);
    }

    private void SpawnPickUp()
    {
        if(_pickUps!=null)
        {
            int randomNumber = Random.Range(0, _pickUps.Length);
            Instantiate(_pickUps[randomNumber], RandomNavmeshLocation(50f),Quaternion.identity);
        }
    }

    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius + transform.position;
        NavMeshHit hit;
        return NavMesh.SamplePosition(randomDirection, out hit, radius, 1) ? hit.position : Vector3.zero;
    }
}
