using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentState : MonoBehaviour
{
    [field: SerializeField, Tooltip("list for the environment objects")]
    public List<Transform> EnvironmentPieces { get; protected set; }

    /// <summary>
    /// Invoked when the toggle is off to remove the portals
    /// </summary>
    public static event Action<Timeline> OnToggleOff;

    protected enum ToggledTimeline
    {
        // None,
        // Current,
        // Past
        On,
        Off
    }

    protected Timeline _activeTimeline;
    protected ToggledTimeline _toggledTimeline;



    // Game Loop Methods---------------------------------------------------------------------------

    protected void Awake()
    {
        EnvironmentPieces = new List<Transform>();
    }
    
    protected virtual void Start()
    {
        _activeTimeline = Timeline.Current;
        // _activeTimeline = ActiveTime.Past;

        _toggledTimeline = ToggledTimeline.Off;

        LevelManager.Instance.OnEnvironmentToggleSwitch += LevelManager_EnvironmentToggleSwitched;
        LevelManager.Instance.OnEnvironmentSwitched += LevelManager_EnvironmentSwitched;
        FillTheObjectsList();
        
        InitializeEnvironment();
    }

    protected virtual void OnDisable()
    {
        LevelManager.Instance.OnEnvironmentToggleSwitch -= LevelManager_EnvironmentToggleSwitched;
        OnToggleOff = null;
    }

    // Member Methods------------------------------------------------------------------------------

    protected void FillTheObjectsList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            EnvironmentPieces.Add(transform.GetChild(i));
        }
    }


    /// <summary>
    /// Change the state of the envronmnet piceses to active or false
    /// </summary>
    protected void SetEnvironmentState(bool isActive)
    {
        foreach (var peice in EnvironmentPieces)
        {
            peice.gameObject.SetActive(isActive);
        }
    }

    protected virtual void InitializeEnvironment() { }

    // Signal Methods------------------------------------------------------------------------------

    protected virtual void LevelManager_EnvironmentToggleSwitched()
    {
        if (_toggledTimeline == ToggledTimeline.Off)
        {
            _toggledTimeline = ToggledTimeline.On;
        }
        else
        {
            _toggledTimeline = ToggledTimeline.Off;
            OnToggleOff?.Invoke(_activeTimeline);
        }
        // if (_activeTimeline == ActiveTime.Current)
        // {
        //     _activeTimeline = ActiveTime.Past;
        //     _toggledTimeline = ToggledTimeline.Past;
        // }
        // else
        // {
        //     _activeTimeline = ActiveTime.Current;
        // }

        Debug.Log($"Parent current state {_activeTimeline}");
    }

    protected virtual void LevelManager_EnvironmentSwitched(Timeline activeTimeline)
    {
        _activeTimeline = activeTimeline;
        _toggledTimeline = ToggledTimeline.Off;
        OnToggleOff?.Invoke(activeTimeline);
    }
}
