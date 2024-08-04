using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput Instance { get; private set; }
    public event Action OnJumpPressed;
    public event Action OnTogglePressed;
    public event Action OnPrimaryFire;
    public event Action OnSecondaryFire;
    public event Action OnClearPortals;

    private PlayerInputAction _playerInputAction;

    private Vector2 _inputVector;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
        _playerInputAction = new PlayerInputAction();
        _playerInputAction.Player.Enable();
    }

    private void Start()
    {
        _playerInputAction.Player.Jump.performed += Jump_Performed;
        _playerInputAction.Player.Preview.performed += Preview_Performed;

        // primary and secondary fire
        _playerInputAction.Player.PrimaryFire.performed += PrimaryFire_Performed;
        _playerInputAction.Player.SecondaryFire.performed += SecondaryFire_Performed;
        _playerInputAction.Player.Clear.performed += Clear_Performed;
    }

    private void Update()
    {
        _inputVector = _playerInputAction.Player.Move.ReadValue<Vector2>();
    }

    private void OnDestroy()
    {
        _playerInputAction.Player.Jump.performed += Jump_Performed;
        _playerInputAction.Player.Preview.performed += Preview_Performed;

        _playerInputAction.Player.PrimaryFire.performed -= PrimaryFire_Performed;
        _playerInputAction.Player.SecondaryFire.performed -= SecondaryFire_Performed;
        _playerInputAction.Player.Clear.performed -= Clear_Performed;

        _playerInputAction.Dispose();
    }

    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------

    private void Jump_Performed(InputAction.CallbackContext context) => OnJumpPressed?.Invoke();
    private void Preview_Performed(InputAction.CallbackContext context) => OnTogglePressed?.Invoke();
    private void PrimaryFire_Performed(InputAction.CallbackContext context) => OnPrimaryFire?.Invoke();
    private void SecondaryFire_Performed(InputAction.CallbackContext context) => OnSecondaryFire?.Invoke();
    private void Clear_Performed(InputAction.CallbackContext context) => OnClearPortals?.Invoke();

    // Getters & Setters---------------------------------------------------------------------------

    public Vector2 InputVector { get => _inputVector; }
    public Vector2 InputVectorNormalized { get => _inputVector.normalized; }
}
