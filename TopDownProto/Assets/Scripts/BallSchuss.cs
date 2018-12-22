using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSchuss : MonoBehaviour {

    public Rigidbody2D Ball;
    public float ShootingForce;
    public Transform BallAbschussPosition;
    public int HP;

    private Rigidbody2D rb2d;

    private bool facingRight;
    private bool facingLeft;
    private bool facingForwards;
    private bool facingBackwards;

    private Vector2 ShootRight = new Vector2(1, 0);
    private Vector2 ShootLeft = new Vector2(-1, 0);
    private Vector2 ShootForwards = new Vector2(0, 1);
    private Vector2 ShootBackwards = new Vector2(0, -1);



    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    public void GetDamage(int damage)
    {
        HP -= damage;
    }



    void Update () {

        if (HP <= 0)
            Destroy(gameObject);
        
        //Facing
        if (Input.GetButtonDown("right"))
        {
            facingRight = true;
            facingLeft = false;
            facingForwards = false;
            facingBackwards = false;
        }
        
        if (Input.GetButtonDown("left"))
        {
            facingRight = false;
            facingLeft = true;
            facingForwards = false;
            facingBackwards = false;
        }
            
        if (Input.GetButtonDown("up"))
        {
            facingRight = false;
            facingLeft = false;
            facingForwards = true;
            facingBackwards = false;
        }

        if (Input.GetButtonDown("down"))
        {
            facingRight = false;
            facingLeft = false;
            facingForwards = false;
            facingBackwards = true;
        }



        //Instantiate
        if (Input.GetButtonDown("Fire1"))
        {                                   
            Rigidbody2D BallInstance;
            BallInstance = Instantiate(Ball, BallAbschussPosition.position, transform.rotation) as Rigidbody2D;
            BallInstance.AddForce(ShootForwards * ShootingForce);

            /*if (facingRight == true)
                BallInstance.AddForce(ShootRight * ShootingForce);
            else if (facingLeft == true)
                BallInstance.AddForce(ShootLeft * ShootingForce);

            if (facingForwards == true)
                BallInstance.AddForce(ShootForwards * ShootingForce);
            else if (facingBackwards == true)
                BallInstance.AddForce(ShootBackwards * ShootingForce);
                */
        }
	}
}
