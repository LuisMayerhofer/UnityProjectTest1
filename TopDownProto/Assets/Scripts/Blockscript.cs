using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockscript : MonoBehaviour {

    public int HP;

    public void GetDamage(int damage)
    {
        HP -= damage;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if ( HP <= 0)
        {
            Destroy(gameObject);
        }

	}
}
