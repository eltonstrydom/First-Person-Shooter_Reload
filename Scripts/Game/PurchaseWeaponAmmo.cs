using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseWeaponAmmo : MonoBehaviour {
	public GameObject purchasePanel;
	bool canBuy;
	public GunHandler gunHandler;
	public float weaponPrice;
	public AudioClip purchaseSound;
	// Use this for initialization
	void Start () {
		canBuy = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F) && canBuy && PlayerScore.SharedInstanceScore.GetCurrentScore () >= weaponPrice) {
			AudioManager.audioManager.PlaySound (purchaseSound);
			PlayerScore.SharedInstanceScore.DecreaseScore (weaponPrice);
			gunHandler.MaxAmmo ();
		}
			
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			canBuy = true;
			purchasePanel.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			canBuy = false;
			purchasePanel.SetActive (false);
		}
	}
}
