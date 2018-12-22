using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float speed;
    public float DashDelay;
    public float DashForce;

    public Rigidbody2D Block;
    public Transform BlockPosition;

    private Rigidbody2D rb2d;
    private Transform Trans;
    private float DashRightTotal = 0;
    private float DashRightTime = 0;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertikal = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertikal);
        rb2d.AddForce(movement * speed);
    }

    private void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            DashRightTotal += 1;
        }
        if ((DashRightTotal == 1) && (DashRightTime < DashDelay))
            DashRightTime += Time.deltaTime;
        if ((DashRightTotal == 1) && (DashRightTime >= DashDelay))
        {
            DashRightTime = 0;
            DashRightTotal = 0;
        }
        if ((DashRightTotal == 2) && (DashRightTime < DashDelay))
        {
            DashRightTotal = 0;
            rb2d.AddForce(new Vector2(DashForce, 0));
        }
        if ((DashRightTotal == 2)&& (DashRightTime >= DashDelay))
        {
            DashRightTime = 0;
            DashRightTotal = 0;
        }
        if (Input.GetKeyDown("space"))
        {
            Instantiate(Block, BlockPosition.position, BlockPosition.rotation);
        }
        
        //Rotation
        /*if (Input.GetButtonDown("right"))
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.back);
        }
                

        if (Input.GetButtonDown("left"))
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.back);
        }
                

        if (Input.GetButtonDown("down"))
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.back);
        }

        if (Input.GetButtonDown("up"))
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.back);
        }  */                          
    }    
}
