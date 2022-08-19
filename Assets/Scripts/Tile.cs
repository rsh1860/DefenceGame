using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private GameObject turret;

    private Renderer render;

    public Color hoverColor;

    private Color originColor;

    public Vector3 offsetPos;

    public Material hoverMaterial;

    private Material startMaterial;

    private void Start()
    {
        render = transform.GetComponent<Renderer>();
        originColor = render.material.color;

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
            return;
        }
        //��ư�� ������ �ʾ��� �� ��ġ�ϴ� ���� ����
        if (BuildManager.instance.GetTurretToBuild() == null) 
        {
            return;
        }

        turret = (GameObject)Instantiate(BuildManager.instance.GetTurretToBuild(), this.transform.position + offsetPos, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }

        //render.material.color = hoverColor;
        render.material = hoverMaterial;
    }

    private void OnMouseExit()
    {
        //render.material.color = originColor;
        render.material = startMaterial;
    }
}
