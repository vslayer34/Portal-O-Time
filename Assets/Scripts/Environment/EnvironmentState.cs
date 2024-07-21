using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentState : MonoBehaviour
{
    [field: SerializeField, Tooltip("list for the environment objects")]
    public List<Transform> EnvironmentPieces { get; protected set; }



    // Game Loop Methods---------------------------------------------------------------------------

    protected void Awake()
    {
        EnvironmentPieces = new List<Transform>();
    }
    
    protected virtual void Start()
    {
        FillTheObjectsList();
        
        InitializeEnvironment();
    }

    // Member Methods------------------------------------------------------------------------------

    protected void FillTheObjectsList()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            EnvironmentPieces.Add(transform.GetChild(i));
        }
    }

    protected virtual void InitializeEnvironment() { }

    // Signal Methods------------------------------------------------------------------------------
}
