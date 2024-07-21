using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public event Action OnLevelStart;
    


    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializeEnvironment();
    }

    // Member Methods------------------------------------------------------------------------------

    private void InitializeEnvironment()
    {
        OnLevelStart?.Invoke();
        Debug.Log("Invoked");
    }
}
