using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = false;
	private Rigidbody2D rb2d;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rb2d.velocity.y);


		float move = Input.GetAxis ("HorizontalP2");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);

		if (move > 0 && !facingRight) 
		{
			Flip ();
		} else if (move < 0 && facingRight) 
		{
			Flip ();
		}
	}

	void Update ()
	{
		if (grounded && Input.GetButtonDown ("JumpP2")) //Make GetButton instead in the future
		{ 
			anim.SetBool ("Ground", false);
			rb2d.AddForce (new Vector2(0, jumpForce));
		}
	}

	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
