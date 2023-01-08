using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterTime : MonoBehaviour
{
    [SerializeField] private float _deactivateAfterSeconds;
    [SerializeField] private bool _disappearUnderGround;


    private void Start()
    {
        if(_disappearUnderGround)
        {
            StartCoroutine("DisappearUnderGround");
        }
        else
        {
            StartCoroutine("Deactivation");
        }
            
    }

    private IEnumerator Deactivation()
    {
        yield return new WaitForSeconds(_deactivateAfterSeconds);
        gameObject.SetActive(false);
  
    }

    private IEnumerator DisappearUnderGround()
    {
        yield return new WaitForSeconds(_deactivateAfterSeconds);
        DeactivateAllColliders();
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);

    }

    private void DeactivateAllColliders()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach(Collider collider in colliders)
        {
            collider.isTrigger = true;
        }
    }



}
