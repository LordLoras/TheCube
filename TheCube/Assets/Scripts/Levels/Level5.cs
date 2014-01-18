using UnityEngine;
using System.Collections;

public class Level5 : MonoBehaviour {

	public float moveSpeed;
	bool movingLeft;
	
	// Update is called once per frame
	void Update () 
	{
		if(movingLeft)
		{
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		}
		if(!movingLeft)
		{
			transform.Translate(-Vector3.left * Time.deltaTime * moveSpeed);
		}
	}


	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.name == "WPLeft")
		{
			movingLeft = false;
		}
		if(coll.name == "WPRight")
		{
			movingLeft = true;
		}
	}

}
