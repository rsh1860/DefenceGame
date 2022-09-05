using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject buildEffectPrefab;

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

    public TurretBlueprint turretToBuildBlueprint;

    //TurretBlueprint�� ����
    //public GameObject basicTurretPrefab;
    //public GameObject missileLauncherPrefab;

    /*
    public bool HasBuildMoney
    {
        get
        {
            return PlayerStats.money >= turretToBuildBlueprint.price;
        }
    }
    */

    private Tile selectedTile;

    public TileUI tileUI;

    private void Start()
    {
        //turretToBuild = basicTurretPrefab;
    }

    public void SelectTile(Tile tile)
    {
        //����� Ÿ���� �ٽ� ����
        if (selectedTile == tile)
        {
            DeSelectedTile();
            
            return;
        }

        selectedTile = tile;

        turretToBuildBlueprint = null;

        tileUI.ShowTileUI(tile);
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuildBlueprint;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuildBlueprint = turret;
        DeSelectedTile();
    }

    private void DeSelectedTile()
    {
        tileUI.HideTileUI();
        selectedTile = null;
    }
}
