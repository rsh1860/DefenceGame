using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public TurretBlueprint basicTurret;
    public TurretBlueprint missileLauncher;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectBasicTurret()
    {
        buildManager.SetTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SetTurretToBuild(missileLauncher);
    }
}
