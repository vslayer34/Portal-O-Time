using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnvironmentState : MonoBehaviour
{
    [field: SerializeField, Tooltip("list for the environment objects")]
    public List<Transform> EnvironmentPieces { get; protected set; }
}
