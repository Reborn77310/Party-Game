using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perso : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
    private Rigidbody2D rigid;
    public float Speed = 100;

    private bool aDroite = true;

    public float gravity = -9.81f;
    public bool OnGround = false;
	void Start ()
	{
	    rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var horizontal = Input.GetAxis("Horizontal");
	    if (Mathf.Abs(horizontal) > 0.2f)
	    {
            velocity.x = Speed * Time.deltaTime * horizontal;
	        if (horizontal > 0 && !aDroite)
	        {
	            aDroite = true;
	            transform.Rotate(0,-180,0);
	        }
	        else if (horizontal < 0 && aDroite)
	        {
	            aDroite = false;
                transform.Rotate(0,180,0);
	        }
        }
	    else
	    {
	        velocity.x = 0;
	    }

	    
	    if (!OnGround)
	    {
	        velocity.y = gravity * Time.deltaTime * 15;
	    }
	 
	    if (Input.GetKeyDown(KeyCode.Space) && OnGround)
	    {
	        rigid.AddForce(Vector3.up * Speed *  20);
	        OnGround = false;
	    }

        rigid.velocity = velocity;
	}


    void OnCollisionEnter2D(Collision2D col)
    {
        if (!OnGround)
        {
            print(col.gameObject.name);
            OnGround = true;
            velocity.y = 0;
        }
    }
}
