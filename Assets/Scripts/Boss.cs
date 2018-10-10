using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    Player player;
    public GameObject glowing;
    public BossCore bossCore;
    public GameObject explosion;
    Core core;

    public GameObject projectile;
    public Text bossHealth;
    public int health;
    private bool spawnGlowing = true;
    int glowingHealth;

    void Start () {
        player = GameObject.FindObjectOfType<Player>();
        core = GameObject.FindObjectOfType<Core>();
        bossHealth = GameObject.FindGameObjectWithTag("bosstext").GetComponent<Text>();
        InvokeRepeating("Shoot", 4f, 2);
        UpdateHealth();
        //InvokeRepeating("ShootAtPlayer", 2f, 2);
    }
	
    void UpdateHealth()
    {
        bossHealth.text = "Boss Health: " + health;
    }

	// Update is called once per frame
	void Update () {
        if (transform.position.y > 9f)
        {
            transform.Translate(new Vector3(0, -0.2f));
        }
        else if (spawnGlowing)
        {
            SpawnGlowings();
            spawnGlowing = false;
        }
    }

    public void SpawnGlowings()
    {
        Instantiate(glowing, transform.position + new Vector3(5, 0), Quaternion.identity);
        Instantiate(glowing, transform.position + new Vector3(-5, 0), Quaternion.identity);
        glowingHealth = 4;
    }
    public int getHealth()
    {
        return this.health;
    }
    public void DecHealth()
    {
        health -= 1;
        UpdateHealth();
        if (health == 0)
        {
            var obj = Instantiate(explosion, transform.position, Quaternion.identity);
            obj.transform.localScale = new Vector3(6, 5);
            var obj2 = Instantiate(explosion, transform.position + new Vector3(1, 0), Quaternion.identity);
            obj2.transform.localScale = new Vector3(6, 5);
            var obj3 = Instantiate(explosion, transform.position + new Vector3(-1, 0.3f), Quaternion.identity);
            obj3.transform.localScale = new Vector3(6, 5);
            core.PlaySound(4);
            core.End();
            Destroy(gameObject);
        }
    }

    public void DecGlowingHealth()
    {
        glowingHealth -= 1;
        if (glowingHealth == 0)
        {
            Instantiate(bossCore, transform.position, Quaternion.identity);

        }
    }

    void ShootAtPlayer()
    {
        GameObject rocketClone = Instantiate(projectile, transform.position, transform.rotation);
        rocketClone.transform.LookAt(player.transform);
        rocketClone.transform.GetComponent<Rigidbody2D>().AddForce(rocketClone.transform.forward * 1000);
    }

    void Shoot()
    {
        float deg = -45;
        while (deg < 45)
        {
            GameObject rocketClone = Instantiate(projectile, transform.position, Quaternion.identity);
            rocketClone.transform.eulerAngles = new Vector3(0, 0, deg + 180);
            rocketClone.transform.GetComponent<Rigidbody2D>().AddForce(rocketClone.transform.up * 300);
            deg += 4;
        }
    }
}
