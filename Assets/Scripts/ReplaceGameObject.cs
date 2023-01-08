using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceGameObject : MonoBehaviour
{
    [SerializeField] private GameObject _replaceWith;


    public void Replace()
    {
        Instantiate(_replaceWith, transform.position, Quaternion.identity);
    }
}
