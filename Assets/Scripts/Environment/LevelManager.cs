using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Timeline
{
    Current,
    Past
}


public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public event Action<Timeline> OnEnvironmentSwitched;

    [SerializeField, Tooltip("reference to the level resources")]
    private SO_LevelResources _levelResources;

    public Action OnEnvironmentToggleSwitch;
    private Timeline _activeTimeline;
    


    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _activeTimeline = Timeline.Current;
        PlayerInput.Instance.OnTogglePressed += PlayerInput_OnSwitchPressed;
        PlayerInput.Instance.OnClearPortals += PlayerInput_OnClearPortals;
    }

    private void OnDisable()
    {
        PlayerInput.Instance.OnTogglePressed -= PlayerInput_OnSwitchPressed;
        PlayerInput.Instance.OnClearPortals -= PlayerInput_OnClearPortals;
    }

    // Member Methods------------------------------------------------------------------------------
    public void SwitchEnvironment()
    {
        if (_activeTimeline == Timeline.Current)
        {
            _activeTimeline = Timeline.Past;
            OnEnvironmentSwitched?.Invoke(_activeTimeline);
        }
        else
        {
            _activeTimeline = Timeline.Current;
            OnEnvironmentSwitched?.Invoke(_activeTimeline);
        }
    }

    // Signal Methods------------------------------------------------------------------------------

    private void PlayerInput_OnSwitchPressed() => Instance.OnEnvironmentToggleSwitch?.Invoke();
    private void PlayerInput_OnClearPortals()
    {
        _levelResources.BluePortal.gameObject.SetActive(false);
        _levelResources.OrangePortal.gameObject.SetActive(false);
    }
    // Getters & Setters---------------------------------------------------------------------------

    public Timeline ActiveTimeline { get => _activeTimeline; }
    public SO_LevelResources LevelResources { get => _levelResources; }
}
