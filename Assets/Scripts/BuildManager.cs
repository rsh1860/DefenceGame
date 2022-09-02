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

    private TurretBlueprint turretToBuildBlueprint;

    //TurretBlueprint로 관리
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

    public void OnBuildTurret(Tile tile)
    {
        /* if (!PlayerStats.HaveMoney(turretToBuildBlueprint.price))
         {
             Debug.Log("돈이 부족합니다.");
             return;
         }*/

        if (PlayerStats.UseMoney(turretToBuildBlueprint.price))
        {
            Vector3 buildPos = tile.GetBuildPosition() + turretToBuildBlueprint.offsetPos;
            GameObject _turret = (GameObject)Instantiate(turretToBuildBlueprint.prefab, buildPos, Quaternion.identity);
            tile.turret = _turret;

            GameObject effect = Instantiate(buildEffectPrefab, tile.GetBuildPosition(), Quaternion.identity);
            Destroy(effect.gameObject, 2f);
        }              
    }

    public void SelectTile(Tile tile)
    {
        //저장된 타일을 다시 선택
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
