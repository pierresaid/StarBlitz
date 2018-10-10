using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_generator : MonoBehaviour {

    public GameObject explosion;

    // Use this for initialization
    void Start () {
        InvokeRepeating("explode", 0, 0.2f);

    }

    // Update is called once per frame
    void Update () {
		
	}

    void explode()
    {
        Instantiate(explosion, new Vector3(Random.Range(-25, 22), Random.Range(-13, 12), 0), Quaternion.identity);
    }
}
