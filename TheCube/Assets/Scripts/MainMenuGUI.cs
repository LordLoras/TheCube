using UnityEngine;
using System.Collections;
using Nini.Config;

public class MainMenuGUI : MonoBehaviour {
	
	public float sizeY = 0.1f;
	public float sizeX = 0.5f;
	int screenX = Screen.width;
	int screenY = Screen.height;

	
	void OnGUI()
	{
		 

		if(GUI.Button(new Rect(screenX * 0.25f , screenY * 0.25f , screenX * sizeX , screenY * sizeY),"Play"))
		{
			//load level select
			Application.LoadLevel("LevelSelect");
		}
		if(GUI.Button(new Rect(screenX * 0.25f , screenY * 0.40f , screenX * sizeX , screenY * sizeY),"Options"))
		{
			//call options ?!
			PlayerPrefs.DeleteAll();
		}
		if(GUI.Button(new Rect(screenX * 0.25f , screenY * 0.55f , screenX * sizeX , screenY * sizeY),"Quit"))
		{
			//quit
			Application.Quit();
		}




	}


}
