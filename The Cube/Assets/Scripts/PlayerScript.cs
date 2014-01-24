using UnityEngine;
using System.Collections;
using Nini.Config;

public class PlayerScript : MonoBehaviour {

	public float moveForce;
	public float jumpForce;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	float groundRadius = 0.2f;
	bool grounded = false;
	Animator anim;
	IConfigSource source;
	GameObject StartPos;
	string PlayerColor = "White";

	// Use this for initialization
	void Start () {
		//ref the animator
		anim = GetComponent<Animator>();
		//setup the ini
		source = new IniConfigSource(Application.dataPath + @"/savefile.ini");

		//reference to start pos obj
		StartPos = GameObject.FindWithTag("StartPosition");
		//set player pos @ start point
		transform.position = StartPos.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		#region temp random events
		if(Input.GetKey(KeyCode.F1))
		{
			transform.position = StartPos.transform.position;
		}
		#endregion

		#region player_movement
		bool jump = Input.GetButtonDown("Jump");
		if(jump && grounded)
		{
			rigidbody2D.AddForce(new Vector2(0,0));
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
		}

		#endregion

		#region player colors

		if(Input.GetButtonDown("Black"))
		{
			PlayerColor = "Black";
			anim.Play("Player_Black");
			
		}
		if(Input.GetButtonDown("White"))
		{
			PlayerColor = "White";
			anim.Play("Player_White");
			
		}
		
		if(Input.GetButtonDown("Blue"))
		{
			PlayerColor = "Blue";
			anim.Play("Player_Blue");
			
		}
		
		if(Input.GetButtonDown("Orange"))
		{
			PlayerColor = "Orange";
			anim.Play("Player_Orange");
			
		}

		#endregion

	
	}

	void FixedUpdate()
	{

		#region player_movement
		grounded = Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		float move = Input.GetAxis("Horizontal");	
		rigidbody2D.velocity = new Vector2(move * moveForce, rigidbody2D.velocity.y);


		#endregion

	}


	#region on trigger enter
	void OnTriggerEnter2D(Collider2D coll) 
	{
	if(coll.name == "EndPoint")
	{
			//mark level as passed
			source.Configs["Levels"].Set(Application.loadedLevelName,"1");
			source.Save();
			//load next level
			int nextlevel = int.Parse(Application.loadedLevelName.Substring(5)) + 1;
			Application.LoadLevel("Level" + nextlevel);
			Debug.Log("END LEVEL");

	}

	if(coll.name == "death")
	{
			transform.position = StartPos.transform.position;
	}

	}

	#endregion

	#region on collision stay
	void OnCollisionStay2D(Collision2D coll)
	{

		if(coll.collider.name == "Black" && PlayerColor != "Black")
		{
			transform.position = StartPos.transform.position;
		}
		if(coll.collider.name == "White" && PlayerColor != "White")
		{
			transform.position = StartPos.transform.position;
		}
		if(coll.collider.name == "Blue" && PlayerColor != "Blue")
		{
			transform.position = StartPos.transform.position;
		}
		if(coll.collider.name == "Orange" && PlayerColor != "Orange")
		{
			transform.position = StartPos.transform.position;
		}

		if(coll.collider.name == "Enemy")
		{
			transform.position = StartPos.transform.position;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.name == "Enemy")
		{
			transform.position = StartPos.transform.position;
		}

		#region EXPERIMENTAL REMOVE ON FAILURE
		if(coll.collider.name == "Black" && PlayerColor != "Black")
		{
			transform.position = StartPos.transform.position;
		}
		if(coll.collider.name == "White" && PlayerColor != "White")
		{
			transform.position = StartPos.transform.position;
		}
		if(coll.collider.name == "Blue" && PlayerColor != "Blue")
		{
			transform.position = StartPos.transform.position;
		}
		if(coll.collider.name == "Orange" && PlayerColor != "Orange")
		{
			transform.position = StartPos.transform.position;
		}
		#endregion

	}
	#endregion
}
