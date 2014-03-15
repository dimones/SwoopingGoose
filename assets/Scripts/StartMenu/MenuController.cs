using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public GUIStyle _style;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		if (GUI.Button (new Rect (Screen.width / 2 - 220, Screen.height / 2 + 200, 400, 250), "START",_style)) {

			Application.LoadLevel("Game");
				}
		if (GUI.Button (new Rect (Screen.width / 2 +220, Screen.height / 2 + 200, 400, 250), "EXIT", _style)) {
			
			Application.Quit();
		}

		}
}
