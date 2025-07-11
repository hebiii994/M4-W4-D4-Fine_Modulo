using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GroundChecker _groundCheck;
    private Vector3 _dir;

    private Transform _mainCameraTransform;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _groundCheck = GetComponent<GroundChecker>();
        _mainCameraTransform = Camera.main.transform;

    }

    private void Update()
    {
        HandleInput();

        if (Input.GetButtonDown("Jump") && _groundCheck.IsGrounded)
        {
            Jump();
        }
    }


    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 forward = _mainCameraTransform.forward;
        Vector3 right = _mainCameraTransform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        _dir = (forward * y + right * x).normalized;
    }

    private void HandleMovement()
    {
        Vector3 movement = _dir * _speed;
        movement.y = _rb.velocity.y;
        _rb.velocity = movement;
    }

    private void Jump()
    {
        _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }
    private void HandleRotation()
    {
        if (_dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation( _dir, Vector3.up);
            _rb.rotation = Quaternion.Slerp(_rb.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }


}
