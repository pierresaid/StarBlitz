using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemy_destroy_on_exit_map : MonoBehaviour
{
    WaveSpawner waveSpawner;

    void Start()
    {
        waveSpawner = FindObjectOfType<Core>().GetComponent<WaveSpawner>();

    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ennemie")
        {
            Destroy(collision.gameObject);
            yield return new WaitForEndOfFrame();
            if (GameObject.FindGameObjectsWithTag("ennemie").Length == 0)
                waveSpawner.SpawNextWave();
        }

    }

}
