using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCore : MonoBehaviour
{

    Boss boss;
    Core core;
    void Start()
    {
        core = GameObject.FindObjectOfType<Core>();
        boss = FindObjectOfType<Boss>();
        Invoke("hara_kiri", 5);
    }
    void hara_kiri()
    {
        boss.SpawnGlowings();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            core.PlaySound(2);
            if (boss.getHealth() == 1)
                Destroy(gameObject);
            boss.DecHealth();
            Destroy(collision.gameObject);
        }
    }
}
