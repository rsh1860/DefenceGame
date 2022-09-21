using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundSurvived : MonoBehaviour
{
    public TextMeshProUGUI roundText;

    private void OnEnable()
    {
        StartCoroutine(AnimateNumberText(PlayerStats.rounds));
    }

    IEnumerator AnimateNumberText(int targetNumber)
    {
        int aniNumber = 0;
        roundText.text = aniNumber.ToString();
        yield return new WaitForSeconds(0.05f);

        while (aniNumber < targetNumber)
        {
            aniNumber++;
            roundText.text = aniNumber.ToString();
            yield return new WaitForSeconds(0.05f);
        }    
    }
}
