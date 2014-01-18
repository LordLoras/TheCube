using UnityEngine;
using System.Collections;

public class Level3 : MonoBehaviour {
	public float jumpForce;
	Vector3 position;

	void Start()
	{
		position = transform.position;

	}

	void Update()
	{

		if(rigidbody2D.velocity.x != 0)
		{
			rigidbody2D.velocity = new Vector2(0,0);
			transform.position = new Vector3(position.x,transform.position.y,0f);
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.name == "Neutral")
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);

		}

	}
}
