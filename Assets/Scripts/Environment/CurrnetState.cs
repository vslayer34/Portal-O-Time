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
        if (_activeTimeline == Timeline.Current)
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
                break;
            
            case Timeline.Past:
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


    protected override void LevelManager_EnvironmentSwitched(Timeline activeTimeline)
    {
        base.LevelManager_EnvironmentSwitched(activeTimeline);
        switch (activeTimeline)
        {
            case Timeline.Current:
                SetEnvironmentState(true);
                break;

            case Timeline.Past:
                SetEnvironmentState(false);
                break;
            default:
                Debug.LogError("There's no such time state");
                break;
        }
    }
}
