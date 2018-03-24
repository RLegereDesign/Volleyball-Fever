using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 

{

	public GameObject Ball;
	private float timeleft;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeleft += 1;
		if (timeleft > 30)
		{
			Ball.gameObject.SetActive (true);
		}
	}

}
