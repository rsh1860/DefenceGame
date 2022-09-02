using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private BuildManager buildManager;

    public GameObject turret;

    private Renderer render;

    public Material hoverMaterial;

    private Material startMaterial;

    public Material noMoneyMaterial;

    private TurretBlueprint turretBluePrint;

    public GameObject buildEffectPrefab;

    public Vector3 offsetPos;

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
        //�ߺ��� �ڸ��� ��ġ�ϴ� ���� ����
        if (turret != null) 
        {
            buildManager.SelectTile(this);

            return;
        }
        //�ͷ���ư�� ������ �ʾ��� �� ��ġ�ϴ� ���� ����
        if (buildManager.GetTurretToBuild() == null) 
        {
            return;
        }

        buildManager.OnBuildTurret(this);
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
