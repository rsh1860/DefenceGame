using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int price;

    public GameObject upgradePrefab;
    public int upgradePrice;

    public Vector3 offsetPos; //터렛별 설치 위치 보정값
}
