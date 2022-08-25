using UnityEngine;
using TMPro;

public class DrawMoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI lifeText;

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerStats.money + "G";
        lifeText.text = PlayerStats.lives.ToString();
    }
}
