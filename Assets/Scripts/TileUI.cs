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

        selectTile.UpgradeTurret();
        HideTileUI();
    }

    public void Sell()
    {
        Debug.Log("Sell");
    }
}
