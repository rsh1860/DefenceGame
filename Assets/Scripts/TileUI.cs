using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileUI : MonoBehaviour
{
    private Tile selectTile;

    public GameObject ui;

    public Button upgradeButton;

    public TextMeshProUGUI upgradePrice;

    public TextMeshProUGUI sellPrice;

    public void ShowTileUI(Tile tile)
    {
        selectTile = tile;

        transform.position = selectTile.GetBuildPosition();

        if (selectTile.isUpgrade)
        {
            upgradePrice.text = "DONE";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradePrice.text = selectTile.blueprint.upgradePrice.ToString() + "G";
            upgradeButton.interactable = true;
        }
        sellPrice.text = selectTile.blueprint.GetSellPrice().ToString() + "G";

        ui.SetActive(true);
    }

    public void HideTileUI()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        if (selectTile.isUpgrade)
        {
            return;
        }

        if (!PlayerStats.HaveMoney(selectTile.blueprint.upgradePrice))
        {
            Debug.Log("업그레이드에 필요한 돈이 부족합니다.");
            return;
        }

        selectTile.UpgradeTurret();
        HideTileUI();
    }

    public void Sell()
    {
        selectTile.SellTurret();
        BuildManager.instance.DeSelectedTile();
        HideTileUI();
    }
}
