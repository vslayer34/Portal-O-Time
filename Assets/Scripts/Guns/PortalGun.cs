using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour, IWeapon
{
    [SerializeField, Tooltip("Reference to the player shooting script")]
    private ShootPortals _playerPortalControls;

    [SerializeField, Tooltip("Portal projectile")]

    private PortalType _portalType;



    // Game Loop methods---------------------------------------------------------------------------
    private void Start()
    {
        _playerPortalControls.OnPortalGunFired += ShootPortals_OnPortalGunFired;
    }

    // Member Methods------------------------------------------------------------------------------
    private void ShootPortal(PortalType portalType)
    {

    }
    // Signal Methods------------------------------------------------------------------------------

    private void ShootPortals_OnPortalGunFired(object sender, ShootPortals.OnPortalGunFiredEventArgs e)
    {
        
    }
}
