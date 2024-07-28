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
    private Rigidbody _rb;

    [SerializeField, Tooltip("The layer mask for the wall that can hold portals")]
    private LayerMask _portableWallLayer;

    [SerializeField, Header("Material properties"), Tooltip("The material types for the portal")]
    private PortalMaterial _materialVariants;

    [SerializeField, Tooltip("The mesh renderer for the visual asset"), Space(5)]
    private MeshRenderer _projectileMeshRenderer;

    private const float PROJECTILE_SPEED = 500.0f;



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
        _rb.AddForce(direction * PROJECTILE_SPEED);
    }

    private void SetPortalType(PortalType portalType)
    {
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PortableWall portableWall))
        {
            Debug.Log(other.collider.ClosestPoint(transform.position));
        }
        // Debug.Log(other.gameObject.layer == (int)_portableWallLayer);
    }
}