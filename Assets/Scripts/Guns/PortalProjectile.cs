using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
internal struct PortalMaterial
{
    public Material blueMaterial;
    public Material orangeMaterial;
}

public class PortalProjectile : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the rigid body of the projectile")]
    private Rigidbody _rb;

    [SerializeField, Header("Material properties"), Tooltip("The material types for the portal")]
    private PortalMaterial _materialVariants;

    [SerializeField, Tooltip("The mesh renderer for the visual asset"), Space(5)]
    private MeshRenderer _projectileMeshRenderer;



    // Game Loop Methods---------------------------------------------------------------------------

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // private void OnEnable()
    // {
    //     _rb.AddForce(transform.forward * 100);
    // }

    // Memeber Methods-----------------------------------------------------------------------------

    public void InitiatePortal(Vector3 direction, PortalType portalType)
    {
        SetPortalType(portalType);
        _rb.AddForce(direction * 100);
    }

    private void SetPortalType(PortalType portalType)
    {
        Debug.Log(portalType);
        switch (portalType)
        {
            case PortalType.Blue:
                _projectileMeshRenderer.material = _materialVariants.blueMaterial;
                break;

            case PortalType.Orange:
                _projectileMeshRenderer.material = _materialVariants.orangeMaterial;
                break;

            default:
                break;
        }
    }
}