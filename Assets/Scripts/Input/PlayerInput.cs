using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();
    }

    private void Update()
    {
        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------
    // Getters & Setters---------------------------------------------------------------------------

    public Vector2 InputVector { get => _inputVector; }
    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
