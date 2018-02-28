using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
	
	public Texture2D crosshairImage;
	public float width,height,crosshairWidth,crosshairHeight;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void OnGUI()
	{
		float xMin = (Screen.width / width) - (crosshairImage.width / crosshairWidth);
		float yMin = (Screen.height / height) - (crosshairImage.height / crosshairHeight);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}
}
