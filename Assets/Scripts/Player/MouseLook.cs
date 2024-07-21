using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField, Tooltip("The mouse sensitivty")]
    private float _mouseSensitivity;

    [SerializeField, Tooltip("Reference to the player view camera")]
    private Camera _playerView;

    private const float MIN_LOOK_ANGLE = -90.0f;
    private const float MAX_LOOK_ANGLE = 90.0f;

        
    private Vector2 _mouseDelta;
    private float _mouseXDirection;
    private float _mouseYDirection;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseDelta = Mouse.current.delta.ReadValue();

        _mouseXDirection = _mouseDelta.x * _mouseSensitivity * Time.deltaTime;
        _mouseYDirection = _mouseDelta.y * _mouseSensitivity * Time.deltaTime;

        // Horizontal direction
        transform.Rotate(Vector3.up, _mouseXDirection);

        // vertical direction
        
        // The -1 remove invertion and clamp between min and max angles to prevent over rotating
        _mouseYDirection *= -1;
        _mouseYDirection = Mathf.Clamp(_mouseYDirection, MIN_LOOK_ANGLE, MAX_LOOK_ANGLE);

        if (_playerView.transform.forward.y <= MIN_LOOK_ANGLE / 100.0f)
        {
            _playerView.transform.forward = new Vector3(_playerView.transform.forward.x, MIN_LOOK_ANGLE / 100.0f, _playerView.transform.forward.z);
        }
        else if (_playerView.transform.forward.y >= MAX_LOOK_ANGLE / 100.0f)
        {
            _playerView.transform.forward = new Vector3(_playerView.transform.forward.x, MAX_LOOK_ANGLE / 100.0f, _playerView.transform.forward.z);
        }
        else
        {
            _playerView.transform.Rotate(Vector3.right, _mouseYDirection);
        }
    }

    // Memeber Methods-----------------------------------------------------------------------------
    // Getters & Setters---------------------------------------------------------------------------
}
