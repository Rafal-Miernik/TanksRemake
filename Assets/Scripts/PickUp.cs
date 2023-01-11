using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    [SerializeField] GameEvent _gameEvent;

    private void OnTriggerEnter(Collider other)
    {
        if ((_layerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            _gameEvent?.Invoke();
            Destroy(gameObject);
        }

    }
}
