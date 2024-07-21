using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Required Components")]
    private PlayerInput _playerInput;

    private CharacterController _characterController;


    [Space(10), SerializeField, Tooltip("The player movement speed")]
    private float _speed = 10.0f;

    private Vector3 _moveDirection;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveDirection = transform.forward * _playerInput.InputVectorNormalized.y + transform.right * _playerInput.InputVectorNormalized.x;

        Debug.Log(_moveDirection);


        _characterController.Move(_moveDirection * _speed * Time.deltaTime);
    }
}
