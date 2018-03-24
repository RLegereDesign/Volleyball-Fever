using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serve : MonoBehaviour {


	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
		rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			rb.constraints = RigidbodyConstraints2D.None;
		}
		
	}
}
