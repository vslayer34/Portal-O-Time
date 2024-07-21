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
        SetEnvironmentState(true);
    }

    // Signal Methods------------------------------------------------------------------------------

    protected override void LevelManager_EnvironmentStateSwitch()
    {
        base.LevelManager_EnvironmentStateSwitch();
        
        switch (_activeTimeline)
        {
            case ActiveTime.Current:
                SetEnvironmentState(true);
                break;
            
            case ActiveTime.Past:
                SetEnvironmentState(false);
                break;
            
            default:
                Debug.LogError("There's no such state");
                break;
        }
    }
}
