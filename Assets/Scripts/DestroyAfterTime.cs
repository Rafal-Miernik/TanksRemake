using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] private float _destroyAfter;

    private void Start()
    {
        Destroy(gameObject, _destroyAfter);
    }

}
