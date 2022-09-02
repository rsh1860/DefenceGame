using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUI : MonoBehaviour
{
    private Tile selectTile;

    public GameObject ui;

    public Tile tile;

    public void ShowTileUI(Tile tile)
    {
        selectTile = tile;

        transform.position = selectTile.GetBuildPosition();

        ui.SetActive(true);
    }

    public void HideTileUI()
    {
        ui.SetActive(false);
    }
}
