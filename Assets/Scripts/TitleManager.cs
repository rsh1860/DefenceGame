using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public SceneFader fader;

    public GameObject anyKey;

    private bool isShow = false;

    private string loadToScene = "MainMenu";

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("ShowAnyKey", 3f);
        //Invoke("GoToMenu", 13f);
        StartCoroutine(TitleProcess());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && isShow == true)
        {
            StopAllCoroutines();
            GoToMenu();
        }
    }

    private void ShowAnyKey()
    {
        isShow = true;
        anyKey.SetActive(true);
    }

    private void GoToMenu()
    {
        fader.FadeTo(loadToScene);
    }

    IEnumerator TitleProcess()
    {
        yield return new WaitForSeconds(3f);
        ShowAnyKey();

        yield return new WaitForSeconds(10f);
        GoToMenu();
    }
}
