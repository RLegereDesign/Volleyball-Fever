using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour 
{

	public float maxSpeed = 10f;
	bool facingRight = false;
	private Rigidbody2D rb2d;

	public GameObject Ball;
	public Rigidbody2D rb2dball;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;


	bool ballTouched = false;
	public LayerMask whatIsBall;
	public Transform ballCheck;
	float ballRadius = 1.0f;

	private float lastTouched = 0;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator>();

		rb2dball = Ball.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		ballTouched = Physics2D.OverlapCircle (ballCheck.position, ballRadius, whatIsBall);

		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rb2d.velocity.y);


		float move = Input.GetAxis ("HorizontalP1");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);

		if (move > 0 && !facingRight) 
		{
			Flip ();
		} 
		else if (move < 0 && facingRight) 
		{
			Flip ();
		}
		if (ballTouched) 
		{
			lastTouched += 1;
			if (lastTouched == 3) 
			{
				rb2dball.AddForce (new Vector2 (250f, 600f));
				lastTouched = 0;
			}
					
		}
	}
		
	

	void Update ()
	{
		if (grounded && Input.GetButtonDown ("JumpP1")) //Make GetButton instead in the future
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
