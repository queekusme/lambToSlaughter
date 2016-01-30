﻿using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour 
{
	public float maxSpeed = 10.0f;
	bool facingRight = true;

	Animator anim;


	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //flips
		if (move > 0 && !facingRight)
        {
			FlipFacing ();
		} else if (move < 0 && facingRight) 
		{
			FlipFacing ();
		}
	}

	void FlipFacing ()
	{
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}

}
