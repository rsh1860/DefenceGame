using UnityEngine;
using TMPro;

public class DrawMoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerStats.money + "G";
    }
}
