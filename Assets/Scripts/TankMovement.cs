using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TankMovement : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _rotationSpeed;
    private PlayerController _input;
    private float _moveInput;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        _moveInput = _input.FinalInput().y;
        _rigidBody.AddForce(transform.forward * _moveInput * _acceleration);
        _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, _maxSpeed);
    }

    private void HandleRotation()
    {
        Quaternion deltaRotation = Quaternion.Euler(_input.FinalInput().x * new Vector3(0, _rotationSpeed, 0) * Time.deltaTime);
        _rigidBody.MoveRotation(_rigidBody.rotation * deltaRotation);
    }



}
