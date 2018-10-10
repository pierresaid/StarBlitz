using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    private new CircleCollider2D collider;
    public GameObject explosion;

    public float speed;
    private Shooter Shooter;
    private int Level = 0;
    Core core;

    // Use this for initialization
    void Start()
    {
        core = GameObject.FindObjectOfType<Core>();
        Shooter = GetComponent<Shooter>();
        rb2d = GetComponentInParent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        PlayerInteractions();
    }

    private void PlayerInteractions()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var p = transform.position;
            p.y += Mathf.Ceil(collider.radius * transform.localScale.y);
            Shooter.Shoot(p);
        }
    }
    public void LevelUp()
    {
        if (Level >= 3)
            return;
        Level += 1;
        Shooter.LevelUp();
    }
    public void LevelDown()
    {
        Level -= 1;
        Shooter.LevelDown();
        if (Level < 0)
            SceneManager.LoadScene("menu");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "projectile")
        {
            core.PlaySound(3);
            LevelDown();
            Destroy(collision.gameObject);
        }
        else if (collision.collider.tag == "ennemie")
        {
            core.PlaySound(3);
            LevelDown();
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;

        rb2d.rotation = Quaternion.Euler(Vector3.forward * moveHorizontal * -10).z;
    }
}
