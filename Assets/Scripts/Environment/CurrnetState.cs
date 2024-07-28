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
        if (_activeTimeline == ActiveTime.Current)
        {
            SetEnvironmentState(true);
        }
        else
        {
            SetEnvironmentState(false);
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    protected override void LevelManager_EnvironmentToggleSwitched()
    {
        base.LevelManager_EnvironmentToggleSwitched();
        
        switch (_activeTimeline)
        {
            case ActiveTime.Current:
                break;
            
            case ActiveTime.Past:
                if (_toggledTimeline == ToggledTimeline.On)
                {
                    SetEnvironmentState(true);
                }
                else
                {
                    SetEnvironmentState(false);
                }
                break;
            
            default:
                Debug.LogError("There's no such state");
                break;
        }
    }
}
