using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentState : MonoBehaviour
{
    [field: SerializeField, Tooltip("list for the environment objects")]
    public List<Transform> EnvironmentPieces { get; protected set; }

    protected enum ActiveTime
    {
        Current,
        Past
    }

    protected enum ToggledTimeline
    {
        // None,
        // Current,
        // Past
        On,
        Off
    }

    protected ActiveTime _activeTimeline;
    protected ToggledTimeline _toggledTimeline;



    // Game Loop Methods---------------------------------------------------------------------------

    protected void Awake()
    {
        EnvironmentPieces = new List<Transform>();
    }
    
    protected virtual void Start()
    {
        _activeTimeline = ActiveTime.Current;
        // _activeTimeline = ActiveTime.Past;

        _toggledTimeline = ToggledTimeline.Off;

        LevelManager.Instance.OnEnvironmentToggleSwitch += LevelManager_EnvironmentToggleSwitched;
        FillTheObjectsList();
        
        InitializeEnvironment();
    }

    protected virtual void OnDisable()
    {
        LevelManager.Instance.OnEnvironmentToggleSwitch -= LevelManager_EnvironmentToggleSwitched;
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
}
