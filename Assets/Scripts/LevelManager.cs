using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public SceneFader fader;

    public Transform contents;
    private Button[] levelButtons;

    public int nowLevel;

    public RectTransform scrollRect;
    public RectTransform contentsRect;
    public Scrollbar bar;

    //public int nowLevel = 1;

    private void Start()
    {
        nowLevel = PlayerPrefs.GetInt("NowLevel", 1);

        levelButtons = new Button[contents.childCount];

        for (int i = 0; i < levelButtons.Length; i++)
        {
            Transform buttonTrans = contents.GetChild(i);
            levelButtons[i] = buttonTrans.GetComponent<Button>();
            if (i > nowLevel)
            {
                levelButtons[i].interactable = false;
            }
        }

        float scrollHeight = scrollRect.rect.height;
        float contentHeight = 125 + (int) ((levelButtons.Length - 1) / 5) * (125+10);
        float dHeight = contentHeight - scrollHeight;

        //스크롤바 보정
        if (dHeight > 0)
        {
            float nowLevelHeight = (int)((nowLevel - 1) / 5) * 135;
            bar.value = 1 - nowLevelHeight / dHeight;
            if (bar.value < 0) bar.value = 0;
        }
    }

    public void LevelButtonSelect(string sceneName)
    {
        fader.FadeTo(sceneName);
    }
}
