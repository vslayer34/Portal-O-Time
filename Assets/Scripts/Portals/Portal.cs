using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Portal : MonoBehaviour
{
    [SerializeField, Tooltip("The portal type")]
    protected PortalType _portalType;

    [SerializeField, Tooltip("Reference to the game resources")]
    protected SO_LevelResources _LevelResources;

    [SerializeField, Tooltip("Reference to the teleport position")]
    protected Transform _teleportPoint;


    protected BoxCollider _transformArea;
    // determine if the player is teporting or not
    private bool _isPlayerTeleporting;



    // Game Loop Methods---------------------------------------------------------------------------
    private void Awake()
    {
        _transformArea = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        EnvironmentState.OnToggleOff += EnvrinmentState_OnToggleOff;
    }

    private void OnDestroy()
    {
        EnvironmentState.OnToggleOff -= EnvrinmentState_OnToggleOff;
    }

    // Member Methods------------------------------------------------------------------------------

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (_isPlayerTeleporting == false)
        {
            _isPlayerTeleporting = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        _isPlayerTeleporting = false;
    }

    // Signal Methods------------------------------------------------------------------------------
    private void EnvrinmentState_OnToggleOff(Timeline timeline)
    {
        switch (timeline)
        {
            case Timeline.Current:
                _LevelResources.OrangePortal.gameObject.SetActive(false);
                break;

            case Timeline.Past:
                _LevelResources.BluePortal.gameObject.SetActive(false);
                break;
            default:
                Debug.LogError("No such time line");
                break;
        }
    }
    // Getters & Setters---------------------------------------------------------------------------

    public Transform TeleportPoint { get => _teleportPoint; }
}
