using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private float _firePower;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private Transform _shootingPoint;
    private bool _canFire = true;

    public void Shoot()
    {
        if (!this.isActiveAndEnabled) return; //prevent error "coroutine couldn't be started because the gameobject is inactive"

        if (_canFire)
        {
            _shootEffect.Play();
            var currentProjectile = Instantiate(_projectile, _shootingPoint.position, Quaternion.identity);
            currentProjectile.layer = gameObject.layer;
            currentProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * _firePower);
            _canFire = false;
           
            StartCoroutine("Cooldown");
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(_cooldownTime);
        _canFire = true;
    }

}
