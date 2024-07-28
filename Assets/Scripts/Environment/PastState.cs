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
        if (_activeTimeline == ActiveTime.Past)
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
                if (_toggledTimeline == ToggledTimeline.On)
                {
                    SetEnvironmentState(true);
                }
                else
                {
                    SetEnvironmentState(false);
                }
                // SetEnvironmentState(false);
                break;
            
            case ActiveTime.Past:
                // SetEnvironmentState(true);
                break;
            
            default:
                Debug.LogError("There's no such state");
                break;
        }
    }
}
