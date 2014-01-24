using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {
	GameObject startOBJ;
	// Use this for initialization
	void Start () 
	{
		startOBJ = GameObject.Find("StartArea");
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.name == "Player")
		{
			startOBJ.transform.position = transform.position;
		}
	}
}
