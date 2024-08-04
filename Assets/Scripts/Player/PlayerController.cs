using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;


    // Basic Movement

    [Space(10), SerializeField, Tooltip("The player movement speed")]
    private float _speed = 10.0f;

    private Vector3 _moveDirection;

    
    // Gravity and jumping

    private Vector3 _verticalVelocity;
    private const float GRAVITY = -9.8f;
    private const float GROUND_CHECK_SPHERE_RADIUS = 0.1f;
    private bool _isGrounded;

    [SerializeField, Tooltip("Layer maask for ground surfaces")]
    private LayerMask _groundLayerMask;

    [SerializeField, Tooltip("The player jumping force")]
    private float _jumpngForce;

    private bool _isJumping;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        PlayerInput.Instance.OnJumpPressed += PlayerInput_OnJumpPressed;
    }

    private void Update()
    {
        IsGrounded = Physics.CheckSphere(transform.position, GROUND_CHECK_SPHERE_RADIUS, _groundLayerMask);

        _moveDirection = transform.forward * PlayerInput.Instance.InputVectorNormalized.y + transform.right * PlayerInput.Instance.InputVectorNormalized.x;

        if (!_isGrounded)
        {
            _verticalVelocity.y += GRAVITY * Time.deltaTime;
        }


        _characterController.Move(_moveDirection * _speed * Time.deltaTime);

        _characterController.Move(_verticalVelocity * Time.deltaTime);
    }

    private void OnDisable()
    {
        PlayerInput.Instance.OnJumpPressed -= PlayerInput_OnJumpPressed;
    }

    // Signal Methods------------------------------------------------------------------------------

    private void PlayerInput_OnJumpPressed()
    {
        if (IsGrounded)
        {
            _isJumping = true;
            _verticalVelocity.y = _jumpngForce;
        }
    }

    // Getters & Setters---------------------------------------------------------------------------

    public bool IsGrounded
    {
        get => _isGrounded;
        set
        {
            if (value == true && !_isJumping)
            {
                _verticalVelocity.y = 0.0f;
                _isJumping = false;
                _isGrounded = value;
            }
            else
            {
                _isGrounded = value;
            }
        }
    }

    public CharacterController CharacterController { get => _characterController; }
}
