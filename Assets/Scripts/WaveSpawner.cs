using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public GameObject ennemy;
    public GameObject ennemy2;
    public GameObject boss;

    Background background;
    public int NbEnnemyPerWave;
    bool wave = false;
    // Use this for initialization
    void Start () {
        SpawNextWave();
        Invoke("InvokeBoss", 30f);
        background = FindObjectOfType<Background>();
    }

    // Update is called once per frame
    void Update () {
    }

    void InvokeBoss()
    {
        Invoke("SpawnBoss", 3f);
        background.SlowDown();
        cleanup();
    }

    void SpawnBoss()
    {
        Instantiate(boss, new Vector3(0, 21, 0), Quaternion.identity);
    }

    private static void cleanup()
    {
        var ennemies = GameObject.FindGameObjectsWithTag("ennemie");
        foreach (var ennemy in ennemies)
        {
            Destroy(ennemy.gameObject);
        }
        var projectiles = GameObject.FindGameObjectsWithTag("projectile");
        foreach (var p in projectiles)
        {
            Destroy(p.gameObject);
        }
        var powerups = GameObject.FindGameObjectsWithTag("powerup");
        foreach (var powerup in projectiles)
        {
            Destroy(powerup.gameObject);
        }
    }

    public void SpawNextWave()
    {
        if (wave == false)
            SpawnWaveOne();
        else
            SpawnWaveTwo();
        wave = !wave;
    }

    void SpawnWaveOne()
    {
        Instantiate(ennemy, new Vector3(-10, 20, 0), Quaternion.identity);
        Instantiate(ennemy, new Vector3(-7, 17, 0), Quaternion.identity);
        Instantiate(ennemy, new Vector3(-4, 14, 0), Quaternion.identity);
        Instantiate(ennemy, new Vector3(-1, 17, 0), Quaternion.identity);
        Instantiate(ennemy, new Vector3(2, 20, 0), Quaternion.identity);
    }
    void SpawnWaveTwo()
    {
        int x = -20;
        int y = 20;
        for (int i = 0; i < NbEnnemyPerWave; i++)
        {
            Debug.Log(x);
            Instantiate(ennemy2, new Vector3(x, y, 0), Quaternion.identity);
            x += 8;
            if (x > 14)
            {
                x = -20;
                y -= 4;
            }
        }
    }
}
