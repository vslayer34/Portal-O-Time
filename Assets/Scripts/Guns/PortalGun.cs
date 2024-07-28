using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour, IWeapon
{
    [SerializeField, Tooltip("Reference to the player shooting script")]
    private ShootPortals _playerPortalControls;

    [SerializeField, Tooltip("Reference to the projectiles spawn point")]
    private Transform _portalsExitPotint;

    [SerializeField, Tooltip("Portal projectile"), Space(5)]
    private PortalProjectile _portalProjectile;

    private PortalType _portalType;

    // Keep track of the blue and orange portals
    private int _bluePortalsAmount;
    private int _orangePortalsAmount;



    // Game Loop methods---------------------------------------------------------------------------
    private void Start()
    {
        _playerPortalControls.OnPortalGunFired += ShootPortals_OnPortalGunFired;
    }

    // Member Methods------------------------------------------------------------------------------
    private void ShootPortal(PortalType portalType)
    {
        var newPortal = Instantiate(_portalProjectile, _portalsExitPotint.position, _portalsExitPotint.rotation);
        newPortal.InitiatePortal(transform.forward, portalType);

        if (portalType == PortalType.Blue)
        {
            // _bluePortalsAmount++;
        }
        else
        {
            // _orangePortalsAmount++;
        }
    }
    // Signal Methods------------------------------------------------------------------------------

    private void ShootPortals_OnPortalGunFired(object sender, ShootPortals.OnPortalGunFiredEventArgs e)
    {
        ShootPortal(e.portalType);
    }
}
