using UnityEngine;
using System.Collections;


public class ActionManager : MonoBehaviour {

	#region public vars
	public bool CanBlink;
	public float waitTime;
	public bool CanBoost;
	public float boostSpeed;   
	public bool CanJump;
	public float jumpForce;
	public bool CanMoveLeft;
	public float moveSpeedLeft;
	public bool CanMoveDown;
	public float moveSpeedDown;
	public bool CanRotate;
	public float rotationSpeed;
	public bool CanShift;
	#endregion



	Vector3 position;
	bool hidden = false;
	bool movingLeft;
	bool movingDown;
	bool shiftColor = true;
	float colorID;
	Color color;

	void Start()
	{
		position = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		#region jump
		if(CanJump)
		{
			if(rigidbody2D.velocity.x != 0)
			{
				rigidbody2D.velocity = new Vector2(0,0);
				transform.position = new Vector3(position.x,transform.position.y,0f);
			}
		}
		#endregion

		#region Blink
		if(CanBlink)
		{
			if(!hidden)
				StartCoroutine("Blink");
		}
		#endregion


		#region Booster
		if(CanBoost)
		{
		transform.Translate(Vector3.up * boostSpeed * Time.deltaTime);
		}
		#endregion

		#region Move Left
		if(CanMoveLeft)
		{
		if(movingLeft)
		{
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeedLeft);
		}
		if(!movingLeft)
		{
			transform.Translate(-Vector3.left * Time.deltaTime * moveSpeedLeft);
		}
		}
		#endregion

		#region Move Down
		if(CanMoveDown)
		{
		if(movingDown)
		{
			rigidbody2D.velocity = new Vector2(0f,-moveSpeedDown);
		}
		if(!movingDown)
		{
			rigidbody2D.velocity = new Vector2(0f,moveSpeedDown);
		}
		}
		#endregion

		#region RotateObject
		if(CanRotate)
		{
			transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
		}
		#endregion

		#region ShiftColor
		if(CanShift)
		{
		if(shiftColor)
		{
			StartCoroutine("ShiftColor");
		}
		}
		#endregion

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.name == "Neutral" && CanJump)
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		
			
		}
		
	}

	IEnumerator Blink()
	{
		renderer.enabled = true;
		collider2D.enabled = true;
		hidden = true;
		yield return new WaitForSeconds(waitTime*0.5f);
		renderer.enabled = false;
		collider2D.enabled = false;
		yield return new WaitForSeconds(waitTime*0.5f);
		hidden = false;
	}

	IEnumerator ShiftColor()
	{
		shiftColor = false;
		colorID = Random.Range(0,4);
		
		if(colorID == 0)
		{
			gameObject.name = "White";
			renderer.material.color = new Color(1f,1f,1f);
		}
		if(colorID == 1)
		{
			gameObject.name = "Black";
			renderer.material.color = new Color(0f,0f,0f);
		}
		if(colorID == 2)
		{
			gameObject.name = "Blue";
			renderer.material.color = new Color(0.05f,0.46f,0.705f,1f);
		}
		
		if(colorID == 3)
		{
			gameObject.name = "Orange";
			renderer.material.color = new Color(0.945f,0.53f,0f,1f);
		}
		yield return new WaitForSeconds(1f);
		shiftColor = true;
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
