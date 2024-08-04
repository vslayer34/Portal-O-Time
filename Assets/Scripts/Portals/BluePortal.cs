using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortal : Portal
{
    // Member Methods------------------------------------------------------------------------------

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (_LevelResources.OrangePortal.gameObject.activeSelf)
            {
                Debug.Log(_LevelResources.OrangePortal.transform.position);

                player.SetCharacterControllerActive(false);
                player.transform.position = _LevelResources.OrangePortal.TeleportPoint.position;
                player.transform.forward = _LevelResources.OrangePortal.TeleportPoint.transform.forward;
                player.SetCharacterControllerActive(true);

                LevelManager.Instance.SwitchEnvironment();
            }
            else
            {
                Debug.Log("No orange portal is available");
            }
        }
    }
}
