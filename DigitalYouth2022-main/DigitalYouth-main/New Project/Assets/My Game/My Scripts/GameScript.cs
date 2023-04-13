using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
    public EnemySpawner enemySpawner;
    public int enemiesToSpawn;
    public int waveToWin = 3;
    public int waveCount;
    public GameObject cutScene;



    // Use this for initialization
    protected void Start() {
    enemiesToSpawn=Random.Range(1,5);
    cutScene.SetActive(false);


    }


    public void Spawnwave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemySpawner.Spawn();
        }

    }

    // Update is called once per frame
    protected void Update()
    {
        if (EnemySpawner.activated && enemySpawner.transform.childCount == 0)
        {
            if (waveCount>=waveToWin)
            {
                cutScene.SetActive(true);
                enemySpawner.gameObject.SetActive(false);
            }
            if (waveCount < waveToWin)
            {
                waveCount++;
                HUD.Message("Round nr" + waveCount);
                Spawnwave();
            }
        }

    }
}