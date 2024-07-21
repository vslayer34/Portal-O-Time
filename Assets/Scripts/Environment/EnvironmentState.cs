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

    protected ActiveTime _activeTimeline;



    // Game Loop Methods---------------------------------------------------------------------------

    protected void Awake()
    {
        EnvironmentPieces = new List<Transform>();
    }
    
    protected virtual void Start()
    {
        _activeTimeline = ActiveTime.Current;
        LevelManager.Instance.OnEnvronmentStateSwitch += LevelManager_EnvironmentStateSwitch;
        FillTheObjectsList();
        
        InitializeEnvironment();
    }

    protected virtual void OnDisable()
    {
        LevelManager.Instance.OnEnvronmentStateSwitch -= LevelManager_EnvironmentStateSwitch;
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

    protected virtual void LevelManager_EnvironmentStateSwitch()
    {
        if (_activeTimeline == ActiveTime.Current)
        {
            _activeTimeline = ActiveTime.Past;
        }
        else
        {
            _activeTimeline = ActiveTime.Current;
        }

        Debug.Log($"Parent current state {_activeTimeline}");
    }
}
