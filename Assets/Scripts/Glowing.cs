using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowing : MonoBehaviour {

    int health = 2;
    Boss boss;
    Core core;
    void Start()
    {
        core = GameObject.FindObjectOfType<Core>();
        boss = FindObjectOfType<Boss>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "projectile")
        {
            health -= 1;
            core.PlaySound(2);
            boss.DecGlowingHealth();
            Destroy(collision.gameObject);
            if (health == 0)
                Destroy(gameObject);
        }
    }
}
