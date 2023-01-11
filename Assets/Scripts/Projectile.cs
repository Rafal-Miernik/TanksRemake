using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _power;
    [SerializeField] private GameObject _explosionParticles;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == this.gameObject.layer)
            return;



        Instantiate(_explosionParticles, transform.position, Quaternion.identity);
        var damageableObject = other.GetComponent<Damageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeDamage(_power);
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_rigidBody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);
        }

    }

}
