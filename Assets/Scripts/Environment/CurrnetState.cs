using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrnetState : EnvironmentState
{
    // Game Loop Methods---------------------------------------------------------------------------
    protected override void Start()
    {
        base.Start();
    }

    // Member Methods------------------------------------------------------------------------------
    protected override void InitializeEnvironment()
    {
        foreach (var environmentObject in EnvironmentPieces)
        {
            environmentObject.gameObject.SetActive(true);
            Debug.Log($"{environmentObject.name} enabled");
        }
    }

    // Signal Methods------------------------------------------------------------------------------
}
