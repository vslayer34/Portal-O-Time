using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public Action OnEnvronmentStateSwitch;
    


    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerInput.Instance.OnSwitchPressed += PlayerInput_OnSwitchPressed;
    }

    private void OnDisable()
    {
        PlayerInput.Instance.OnSwitchPressed -= PlayerInput_OnSwitchPressed;
    }

    // Member Methods------------------------------------------------------------------------------

    private void PlayerInput_OnSwitchPressed() => Instance.OnEnvronmentStateSwitch?.Invoke();
}
