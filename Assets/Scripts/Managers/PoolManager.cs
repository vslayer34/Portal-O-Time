using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the level resources SO")]
    private SO_LevelResources _LevelResources;

    private const int POOL_COUNT = 2;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Start()
    {
        foreach (var portal in _LevelResources.AvailablePortals)
        {
            var spawned = Instantiate(portal, Vector3.zero, Quaternion.identity);
            
            if (spawned is OrangePortal orangePortal)
            {
                _LevelResources.OrangePortal = orangePortal;
                _LevelResources.OrangePortal.gameObject.SetActive(false);
            }
            else if (spawned is BluePortal bluePortal)
            {
                _LevelResources.BluePortal = bluePortal;
                _LevelResources.BluePortal.gameObject.SetActive(false);
            }
        }

        // Debug.Log(_LevelResources.BluePortal);
        // Debug.Log(_LevelResources.OrangePortal);
    }

    // Member Methods------------------------------------------------------------------------------
}
