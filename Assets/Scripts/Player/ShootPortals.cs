using System;
using UnityEngine;

public enum PortalType
{
    Blue,
    Orange
}

public class ShootPortals : MonoBehaviour
{
    public event EventHandler<OnPortalGunFiredEventArgs> OnPortalGunFired;
    public class OnPortalGunFiredEventArgs : EventArgs
    {
        public PortalType portalType;
    }



    // Game Loop Methods---------------------------------------------------------------------------
    private void Start()
    {
        PlayerInput.Instance.OnPrimaryFire += PlayerInput_PrimaryFire;
        PlayerInput.Instance.OnSecondaryFire += PlayerInput_SecondaryFire;
    }

    private void OnDisable()
    {
        PlayerInput.Instance.OnPrimaryFire -= PlayerInput_PrimaryFire;
        PlayerInput.Instance.OnSecondaryFire -= PlayerInput_SecondaryFire;
    }
    // Member Methods------------------------------------------------------------------------------
    // Signal Methods------------------------------------------------------------------------------
    private void PlayerInput_PrimaryFire()
    {
        OnPortalGunFired?.Invoke(this, new OnPortalGunFiredEventArgs
        {
            portalType = PortalType.Blue
        });
    }

    private void PlayerInput_SecondaryFire()
    {
        OnPortalGunFired?.Invoke(this, new OnPortalGunFiredEventArgs
        {
            portalType = PortalType.Orange
        });
        
    }
}