using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastState : EnvironmentState
{
    // Game Loop Methods---------------------------------------------------------------------------
    protected override void Start()
    {
        base.Start();
    }

    // Member Methods------------------------------------------------------------------------------
    protected override void InitializeEnvironment()
    {
        Debug.Log("Past State");
        foreach (var environmentObject in EnvironmentPieces)
        {
            environmentObject.gameObject.SetActive(false);
            Debug.Log($"{environmentObject.name} disabled");
        }
    }
    // Signal Methods------------------------------------------------------------------------------
}
