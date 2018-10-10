using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    private int Level = 1;

    // Use this for initialization
    void Start()
    {

    }

    public void LevelUp()
    {
        Level += 1;
    }
    public void LevelDown()
    {
        Level -= 1;
    }
    public void Shoot(Vector3 p)
    {
        float projectileSize = projectile.GetComponent<BoxCollider2D>().size.x;
        if (Level == 1)
        {
            GameObject rocketClone = Instantiate(projectile, p, transform.rotation);
            rocketClone.transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1000);
        }
        else if (Level == 2)
        {
            GameObject projectile1 = Instantiate(projectile, new Vector3(p.x - projectileSize, p.y), transform.rotation);
            GameObject projectile2 = Instantiate(projectile, new Vector3(p.x + projectileSize, p.y), transform.rotation);
            projectile1.transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1000);
            projectile2.transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1000);
        }
        else
        {
            GameObject projectile1 = Instantiate(projectile, new Vector3(p.x - projectileSize * 2, p.y), Quaternion.identity);
            projectile1.transform.eulerAngles = new Vector3(0, 0, 25);
            projectile1.transform.GetComponent<Rigidbody2D>().AddForce(projectile1.transform.up * 1000);

            GameObject projectile2 = Instantiate(projectile, new Vector3(p.x, p.y), transform.rotation);
            projectile2.transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 1000);

            GameObject projectile3 = Instantiate(projectile, new Vector3(p.x + projectileSize * 2, p.y), Quaternion.identity);
            projectile3.transform.eulerAngles = new Vector3(0, 0, -25);
            projectile3.transform.GetComponent<Rigidbody2D>().AddForce(projectile3.transform.up * 1000);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
