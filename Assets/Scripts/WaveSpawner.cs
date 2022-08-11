using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform start;

    public float spawnTimer = 5f;
    private float countdown = 2f;

    private int waveCount = 0;

    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());

            countdown = spawnTimer;
        }
        countdown -= Time.deltaTime;

        //countdownText.text = countdown.ToString();
        //countdownText.text = string.Format("{0:0.0}", countdown);
        countdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveCount++;

        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, start.position, Quaternion.identity);
    }   
}
