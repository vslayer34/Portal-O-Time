using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastState : EnvironmentState
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
        Debug.Log("Past State");
        foreach (var environmentObject in EnvironmentPieces)
        {
            environmentObject.gameObject.SetActive(false);
            Debug.Log($"{environmentObject.name} disabled");
        }
    }
}
