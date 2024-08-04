using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangePortal : Portal
{
    // Member Methods------------------------------------------------------------------------------

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (_LevelResources.BluePortal.gameObject.activeSelf)
            {
                Debug.Log(_LevelResources.BluePortal.transform.position);

                player.SetCharacterControllerActive(false);
                player.transform.position = _LevelResources.BluePortal.TeleportPoint.position;
                player.transform.forward = _LevelResources.BluePortal.TeleportPoint.transform.forward;
                player.SetCharacterControllerActive(true);
            }
            else
            {
                Debug.Log("No orange portal is available");
            }
        }
    }
}
