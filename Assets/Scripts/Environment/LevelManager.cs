using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public enum Timeline
    {
        Current,
        Past
    }

    public Action OnEnvronmentStateSwitch;
    private Timeline _activeTimeline;
    


    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _activeTimeline = Timeline.Current;
        PlayerInput.Instance.OnPreviewPressed += PlayerInput_OnSwitchPressed;
    }

    private void OnDisable()
    {
        PlayerInput.Instance.OnPreviewPressed -= PlayerInput_OnSwitchPressed;
    }

    // Member Methods------------------------------------------------------------------------------

    private void PlayerInput_OnSwitchPressed() => Instance.OnEnvronmentStateSwitch?.Invoke();

    // Getters & Setters---------------------------------------------------------------------------

    public Timeline ActiveTimeline { get => _activeTimeline; }
}
