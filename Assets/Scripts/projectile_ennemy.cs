using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_ennemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "map")
        {
            Destroy(gameObject);
        }
    }
}
