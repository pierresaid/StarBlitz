using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int loopcount = 0;
    // Use this for initialization
    void Start()
    {
        loopcount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "map")
        {
            if (level_manager.bulleth == false)
                Destroy(gameObject);
            else
            {
                if (loopcount == 3)
                {
                    Destroy(gameObject);
                    return;
                }
                if (transform.position.y > 10)
                {

                    var p = new Vector3();
                    p = transform.position;
                    p.y = -13.65f;
                    transform.position = p;
                }
                if (transform.position.x < -24)
                {
                    var p = new Vector3();
                    p = transform.position;
                    p.x = 24;
                    transform.position = p;
                }
                if (transform.position.x > 24)
                {
                    var p = new Vector3();
                    p = transform.position;
                    p.x = -24;
                    transform.position = p;
                }
                loopcount += 1;
                transform.GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);

            }
        }
    }
}
