using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ProjectileLauncher))]
public class PlayerController : MonoBehaviour
{
    private Vector3 _finalInput;
    private ProjectileLauncher _projectileLauncher;

    private void Awake()
    {
        _projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    void OnMove(InputValue value) => _finalInput = value.Get<Vector2>();

    void OnFire()
    {
        _projectileLauncher.Shoot();
    }

    public Vector2 FinalInput()
    {
        return _finalInput;
    }


}
