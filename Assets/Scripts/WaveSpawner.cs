using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public static int enemyAlive = 0;

    public Wave[] waves;

    public GameObject enemyPrefab;

    public Transform start;

    public float spawnTimer = 5f;
    private float countdown = 2f;

    private int waveCount = 0;

    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        enemyAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAlive > 0)
            return;

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
        //if (!GameManager.isGameOver)
            PlayerStats.AddRound(1);

        Wave wave = waves[waveCount];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(wave.delayTime);
        }

        if (waveCount < waves.Length - 1)
        {
            waveCount++;
        }
        else
        {
            gameManager.LevelClear();
            this.enabled = false;
        }
       
    }

    private void SpawnEnemy(GameObject prefab)
    {
        enemyAlive++;

        Instantiate(prefab, start.position, Quaternion.identity);
    }   
}
