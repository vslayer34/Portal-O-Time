using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new level resources manager", menuName = "Level/Scene Resources")]
public class SO_LevelResources : ScriptableObject
{
    public List<GameObject> PortalProjectiles { get; private set; }

    [field: SerializeField, Tooltip("The available portals in game")]
    public List<Portal> AvailablePortals { get; private set; }


    private List<BluePortal> _bluePortalPool = new List<BluePortal>();
    private List<OrangePortal> _orangePortalPool = new List<OrangePortal>();


    private BluePortal _bluePortal;
    private OrangePortal _orangePortal;


    // Member Methods------------------------------------------------------------------------------
    // Getters & Setters---------------------------------------------------------------------------
    public BluePortal BluePortal
    {
        get
        {
            // _bluePortal.gameObject.SetActive(true);
            return  _bluePortal;
        }
        set
        {
            _bluePortal = value;
            // _bluePortal.gameObject.SetActive(false);
        }
    }
    public OrangePortal OrangePortal
    {
        get
        {
            // _orangePortal.gameObject.SetActive(true);
            return  _orangePortal;
        }
        set
        {
            _orangePortal = value;
            // _orangePortal.gameObject.SetActive(false);
        }
    }
}
