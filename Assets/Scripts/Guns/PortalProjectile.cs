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


    [SerializeField, Tooltip("Reference to the level resources")]
    private SO_LevelResources _LevelResources;

    private const float PROJECTILE_SPEED = 500.0f;

    private Vector3 _portalSpawnPoint;

    private PortalType _portalType;



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
        _portalType = portalType;
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
        // Vector3 _portalOffset = new Vector3()
        
        if (other.gameObject.TryGetComponent(out PortableWall portableWall))
        {
            _portalSpawnPoint = other.collider.ClosestPoint(transform.position);
            if (_portalType == PortalType.Orange)
            {
                // Instantiate(
                // _LevelResources.OrangePortal.transform, 
                // _portalSpawnPoint, 
                // portableWall.transform.rotation);

                _LevelResources.OrangePortal.gameObject.SetActive(true);
                // _LevelResources.OrangePortal.transform.position = _portalSpawnPoint;

                _LevelResources.OrangePortal.transform.SetPositionAndRotation(_portalSpawnPoint, portableWall.transform.rotation);


                // Debug.Log(portableWall.transform.localRotation);
                // Debug.Log(other.transform.localRotation);
            }
            else if (_portalType == PortalType.Blue)
            {
                // Instantiate(
                // _LevelResources.BluePortal.transform, 
                // _portalSpawnPoint, 
                // portableWall.transform.rotation);

                _LevelResources.BluePortal.gameObject.SetActive(true);
                // _LevelResources.BluePortal.transform.position = _portalSpawnPoint;

                _LevelResources.BluePortal.transform.SetPositionAndRotation(_portalSpawnPoint, portableWall.transform.rotation);
                _LevelResources.BluePortal.transform.SetLocalPositionAndRotation(_portalSpawnPoint, portableWall.transform.rotation);

                // Debug.Log(other.transform.localRotation);
            }
        }
        // Debug.Log(other.gameObject.layer == (int)_portableWallLayer);
    }
}