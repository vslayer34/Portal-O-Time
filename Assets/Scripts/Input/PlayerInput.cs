using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public event Action OnJumpPressed;

    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();
    }

    private void Start()
    {
        _playerInputAction.Player.Jump.performed += Jump_Performed;
    }

    private void Update()
    {
        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------

    private void Jump_Performed(InputAction.CallbackContext context)
    {
        OnJumpPressed?.Invoke();
    }

    // Getters & Setters---------------------------------------------------------------------------

    public Vector2 InputVector { get => _inputVector; }
    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
