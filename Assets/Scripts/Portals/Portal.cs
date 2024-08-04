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
    private void Start()
    {
        _transformArea = GetComponent<BoxCollider>();
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

    // Getters & Setters---------------------------------------------------------------------------

    public Transform TeleportPoint { get => _teleportPoint; }
}
