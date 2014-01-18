using UnityEngine;
using System.Collections;

public class Level5_B : MonoBehaviour {
	
	public float moveSpeed;
	bool movingDown;
	
	// Update is called once per frame
	void Update () 
	{
		if(movingDown)
		{
			rigidbody2D.velocity = new Vector2(0f,-moveSpeed);
		}
		if(!movingDown)
		{
			rigidbody2D.velocity = new Vector2(0f,moveSpeed);
		}
	}
	
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.name == "WPDown")
		{
			movingDown = false;
			rigidbody2D.velocity = new Vector2(0f,0f);
		}
		if(coll.name == "WPUp")
		{
			movingDown = true;
			rigidbody2D.velocity = new Vector2(0f,0f);
		}
	}
	
}
