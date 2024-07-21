using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;

    private Vector2 _inputDirection;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();
    }

    private void Update()
    {
        _inputDirection = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------
    // Getters & Setters---------------------------------------------------------------------------

    public Vector2 InputDirection { get => _inputDirection; }
    public Vector2 InputDirectionNormalized { get => _inputDirection.normalized; }
}
