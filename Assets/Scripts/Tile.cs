using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private BuildManager buildManager;

    public GameObject turret;

    public TurretBlueprint blueprint;

    private Renderer render;

    public Material hoverMaterial;

    private Material startMaterial;

    public Material noMoneyMaterial;

    private TurretBlueprint turretBluePrint;

    public GameObject buildEffectPrefab;

    public Vector3 offsetPos;

    public bool isUpgrade = false;

    private void Start()
    {
        buildManager = BuildManager.instance;
        render = transform.GetComponent<Renderer>();

        startMaterial = render.material;
    }

    private void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //중복된 자리에 설치하는 것을 막기
        if (turret != null) 
        {
            buildManager.SelectTile(this);

            return;
        }
        //터렛버튼을 누르지 않았을 때 설치하는 것을 막기
        if (buildManager.GetTurretToBuild() == null) 
        {
            return;
        }

        OnBuildTurret(this);
    }

    public void OnBuildTurret(Tile tile)
    {
        /* if (!PlayerStats.HaveMoney(turretToBuildBlueprint.price))
         {
             Debug.Log("돈이 부족합니다.");
             return;
         }*/

        if (PlayerStats.UseMoney(buildManager.turretToBuildBlueprint.price))
        {
            Vector3 buildPos = this.GetBuildPosition() + buildManager.turretToBuildBlueprint.offsetPos;
            GameObject _turret = (GameObject)Instantiate(buildManager.turretToBuildBlueprint.prefab, buildPos, Quaternion.identity);
            this.turret = _turret;

            blueprint = buildManager.turretToBuildBlueprint;

            GameObject effect = Instantiate(buildManager.buildEffectPrefab, buildPos, Quaternion.identity);
            Destroy(effect.gameObject, 2f);
        }
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.UseMoney(blueprint.upgradePrice))
        {
            Destroy(turret.gameObject);
            turret = null;

            Vector3 buildPos = this.GetBuildPosition() + blueprint.offsetPos;
            GameObject _turret = (GameObject)Instantiate(blueprint.upgradePrefab, buildPos, Quaternion.identity);
            this.turret = _turret;

            isUpgrade = true;

            GameObject effect = Instantiate(buildManager.buildEffectPrefab, buildPos, Quaternion.identity);
            Destroy(effect.gameObject, 2f);
        }
    }

    public Vector3 GetBuildPosition()
    {
        return this.transform.position + offsetPos;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (!PlayerStats.HaveMoney(buildManager.GetTurretToBuild().price))
        {
            render.material = noMoneyMaterial;
            return;
        }
        render.material = hoverMaterial;
    }

    private void OnMouseExit()
    {
        render.material = startMaterial;
    }
}
