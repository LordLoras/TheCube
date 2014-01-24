using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {
	GameObject txtOBJ;

	void Start()
	{
		txtOBJ = GameObject.Find("3d_txt");
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.name == "Player")
		{
			txtOBJ.renderer.enabled = true;
			Destroy(this.renderer);
			Destroy(this.collider2D);
		}
	}
}
