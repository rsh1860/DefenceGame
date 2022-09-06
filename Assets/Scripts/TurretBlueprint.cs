using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int price;

    public GameObject upgradePrefab;
    public int upgradePrice;

    public int GetSellPrice()
    {
        return price / 2;
    }

    public Vector3 offsetPos; //�ͷ��� ��ġ ��ġ ������
}
