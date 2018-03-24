using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour {

	public Text scoreDisplay;
	public GameObject Ball;
	public float xAx;
	public float yAx;

	private int score = 0;
	private bool ballCheck = true;

	// Use this for initialization
	void Start () {
		scoreDisplay.text = "Score: 0";
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Ball")
		{
			score++;
			scoreDisplay.text = ("Score: "+score);
			StartCoroutine (SpawnServe ());
			StopCoroutine (SpawnServe ());
			Destroy (other.gameObject);
			ballCheck = false;

		}
			
	}


	IEnumerator SpawnServe ()
	{
		yield return new WaitForSeconds (2);

		if (ballCheck == false) {
			Vector3 Spawn = new Vector3 (xAx, yAx, -1f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (Ball, Spawn, spawnRotation);
			ballCheck = true;
		}
}
}
