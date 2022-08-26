using UnityEngine;
using TMPro;

public class DrawLivesUI : MonoBehaviour
{
    public TextMeshProUGUI lifeText;

    // Update is called once per frame
    void Update()
    {
        lifeText.text = PlayerStats.lives.ToString();
    }
}
