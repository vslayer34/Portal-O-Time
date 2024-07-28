using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField, Tooltip("reference to the level resources")]
    private SO_LevelResources _levelResources;

    public enum Timeline
    {
        Current,
        Past
    }

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
    }

    private void OnDisable()
    {
        PlayerInput.Instance.OnTogglePressed -= PlayerInput_OnSwitchPressed;
    }

    // Member Methods------------------------------------------------------------------------------

    private void PlayerInput_OnSwitchPressed() => Instance.OnEnvironmentToggleSwitch?.Invoke();

    // Getters & Setters---------------------------------------------------------------------------

    public Timeline ActiveTimeline { get => _activeTimeline; }
    public SO_LevelResources LevelResources { get => _levelResources; }
}
