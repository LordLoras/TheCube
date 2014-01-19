using UnityEngine;
using System.Collections;
using Nini.Config;

public class LevelSelectGUI : MonoBehaviour {
	public float pxloffset = 0.5f;
	public float sizeY = 0.1f;
	public float sizeX = 0.5f;
	int screenX = Screen.width;
	int screenY = Screen.height;
	IConfigSource source;
	string[] LevelCount;
	// Use this for initialization
	void Start () 
	{
		source = new IniConfigSource(Application.dataPath + @"/savefile.ini");
		LevelCount = source.Configs["Levels"].GetKeys();
		Debug.Log(LevelCount.Length);

	}
	
	void OnGUI()
	{
		GUILayout.BeginArea(new Rect (25,25,150,300));
		GUILayout.BeginVertical("box");
		for(int i = 1;i < LevelCount.Length+1;i++)
		{
			if(source.Configs["Levels"].GetInt("Level"+i) == 1)
			{
			if( GUILayout.Button("Level " + i) )
			{
				Application.LoadLevel("Level"+i);
				Debug.Log("Loading Level" + i);
			}
			}
		}
		GUILayout.EndVertical();
		GUILayout.EndArea();
	}
}
