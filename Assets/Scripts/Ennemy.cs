using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public new string name;
    public int translation_mode;
    public GameObject powerup;
    WaveSpawner waveSpawner;
    Core core;
    Player player;
    ScoreManager scoreManager;
    public GameObject projectile;
    public GameObject explosion;
    float _t;

    // Use this for initialization
    void Start()
    {
        _t = 0;
        core = GameObject.FindObjectOfType<Core>();
        waveSpawner = core.GetComponent<WaveSpawner>();
        player = GameObject.FindObjectOfType<Player>();
        scoreManager = core.GetComponent<ScoreManager>();
        if (name == "b")
        {
            InvokeRepeating("ShootAtPlayer", Random.Range(0f, 2f), 2);

        }
    }


    void ShootAtPlayer()
    {
        GameObject rocketClone = Instantiate(projectile, transform.position, transform.rotation);
        rocketClone.transform.LookAt(player.transform);
        rocketClone.transform.GetComponent<Rigidbody2D>().AddForce(rocketClone.transform.forward * 1000);
    }

    void FixedUpdate()
    {
        if (translation_mode == 1)
        {
            transform.Translate(Mathf.Sin(_t) * 10 * Time.fixedDeltaTime, -2 * Time.fixedDeltaTime, 0);
            Debug.Log(Mathf.Sin(_t) * 10 * Time.fixedDeltaTime);
        }
        else
        {
            transform.Translate(Mathf.Sin(_t * 2) * Time.deltaTime, -4 * Time.deltaTime, 0);
        }
        _t += 0.09f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "projectile")
            ProjectileCollision(collision);
        else if (collision.collider.tag == "ennemie_boundary")
        {

        }
    }

    private void ProjectileCollision(Collision2D collision)
    {
        if (name == "a")
            scoreManager.AddScore(100);
        if (name == "b")
            scoreManager.AddScore(200);
        if (GameObject.FindGameObjectsWithTag("ennemie").Length == 1)
        {
            Instantiate(powerup, transform.position, Quaternion.identity);
            scoreManager.doubleup();
            core.PlaySound(5);
            //if (name == "a")
            waveSpawner.SpawNextWave();
            //if (name == "b")
            //waveSpawner.SpawnBoss();
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        Debug.Log("Wsh");
        core.PlaySound(2);
        Destroy(this.gameObject);
    }
}
