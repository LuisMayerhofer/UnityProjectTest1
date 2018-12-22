using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public GameObject explosion;
    public int damage;
    public int maxCollisions;

    private int countedCollisions = 0;

    private void OnTriggerEnter2D(Collider2D col)             
    {

        if (col.isTrigger != true && col.CompareTag("Destroyable"))
        {
            col.SendMessageUpwards("GetDamage", damage);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (!col.CompareTag("BallBlue")) 
            countedCollisions += 1;        
        
    }

    private void Update()
    {
        if (countedCollisions > 3 )
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
