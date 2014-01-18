using UnityEngine;
using System.Collections;

public class Level4_B : MonoBehaviour {
	bool shiftColor = true;
	float colorID;
	Color color;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(shiftColor)
		{
			StartCoroutine("ShiftColor");
		}
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
		yield return new WaitForSeconds(1);
		shiftColor = true;
	}
}
