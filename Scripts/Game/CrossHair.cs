using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour {

	public Texture2D crosshair;
	public float screenWidthPos,screenHeightPos;
	public float crossImageWidth,crossImageHeight;



	void OnGUI(){

		//GUI.Label(new Rect(Screen.width/2 - 25 ,Screen.height/2 - 25,50,50),crosshair);
		GUI.Label(new Rect(Screen.width/screenWidthPos - 25 ,Screen.height/screenHeightPos - 25,50,50),crosshair);

	}
}
