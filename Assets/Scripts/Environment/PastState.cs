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
        if (_activeTimeline == Timeline.Past)
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
            case Timeline.Current:
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
            
            case Timeline.Past:
                // SetEnvironmentState(true);
                break;
            
            default:
                Debug.LogError("There's no such state");
                break;
        }
    }

    protected override void LevelManager_EnvironmentSwitched(Timeline activeTimeline)
    {
        base.LevelManager_EnvironmentSwitched(activeTimeline);
        switch (activeTimeline)
        {
            case Timeline.Current:
                SetEnvironmentState(false);
                break;

            case Timeline.Past:
                SetEnvironmentState(true);
                break;
            default:
                Debug.LogError("There's no such time state");
                break;
        }
    }
}
