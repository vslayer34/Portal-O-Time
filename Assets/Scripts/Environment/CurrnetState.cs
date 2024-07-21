using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrnetState : EnvironmentState
{
    // Game Loop Methods---------------------------------------------------------------------------
    protected override void Start()
    {
        base.Start();
        LevelManager.Instance.OnLevelStart += LevelManager_LevelStart;
    }

    // Signal Methods------------------------------------------------------------------------------

    protected override void LevelManager_LevelStart()
    {
        foreach (var environmentObject in EnvironmentPieces)
        {
            environmentObject.gameObject.SetActive(true);
            Debug.Log($"{environmentObject.name} enabled");
        }
    }
}
