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

    private TurretBlueprint turretToBuildBlueprint;

    //TurretBlueprint�� ����
    //public GameObject basicTurretPrefab;
    //public GameObject missileLauncherPrefab;

    private void Start()
    {
        //turretToBuild = basicTurretPrefab;
    }

    public void OnBuildTurret(Tile tile)
    {
        /* if (!PlayerStats.HaveMoney(turretToBuildBlueprint.price))
         {
             Debug.Log("���� �����մϴ�.");
             return;
         }*/

        if (PlayerStats.UseMoney(turretToBuildBlueprint.price))
        {
            GameObject _turret = (GameObject)Instantiate(turretToBuildBlueprint.prefab, tile.GetBuildPosition(), Quaternion.identity);
            tile.turret = _turret;

            Debug.Log($"�ͷ� �Ǽ� �� ���� ��: {PlayerStats.money}");
        }              
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuildBlueprint;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuildBlueprint = turret;
    }
}
