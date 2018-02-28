using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {
	public GameObject settingsPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OpenSettings()
	{
		settingsPanel.SetActive (true);
	}
	public void CloseSettings()
	{
		settingsPanel.SetActive (false);
	}
}
