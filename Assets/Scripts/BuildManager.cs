using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private GameObject turretToBuild;

    public GameObject basicTurretPrefab;

    private void Start()
    {
        turretToBuild = basicTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}