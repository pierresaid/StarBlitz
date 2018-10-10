using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    // Use this for initialization
    Core core;
	void Start () {
        core = GameObject.FindObjectOfType<Core>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.LevelUp();
            core.PlaySound(1);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
