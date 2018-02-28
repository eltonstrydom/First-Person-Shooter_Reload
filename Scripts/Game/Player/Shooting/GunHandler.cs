using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunHandler : MonoBehaviour {

	public Transform bulletSpawn;
	public GameObject lowAmmoWarning;
	public GameObject reloadingDisplay;
	public float bulletCooldown;
	float timer;
	public ParticleSystem fireEffect;


	public float totalBullets;
	public float currentBullets;
	public float bulletsPerRound;
	public float currentRound;

	public Text totalAmmoText;
	public Text currentRoundText;
	public bool isReloading;


	AudioClip fireSound;
	List<GunMain> guns = new List<GunMain>();



	void Start () {
		

		guns.Add(new Gun_AK47());
		totalBullets =    guns[0].totalbullets;
		currentBullets =  guns[0].totalbullets;
		bulletsPerRound = guns[0].bulletsperround;
		bulletCooldown =  guns[0].shootdelay;
		currentRound = bulletsPerRound;

	


		totalAmmoText.text = currentBullets.ToString ();
		currentRoundText.text = currentRound.ToString ();
		fireSound = Resources.Load<AudioClip> ("Sounds/FireSound1");

	}
	

	void Update () {
		if (Input.GetKey (KeyCode.Mouse0) && timer >= bulletCooldown&&!isReloading) {

			Fire();
		}

		if (Input.GetKeyDown (KeyCode.R)&&!isReloading) {
			if (currentBullets != 0&&currentRound!=bulletsPerRound) {
				
				StartCoroutine (ReloadDelay());
			}

			else
				Debug.Log ("No more ammo");
		}
	
		timer += Time.deltaTime;

		float temp = currentBullets / totalBullets * 100;
		if (temp <= 10)
			lowAmmoWarning.gameObject.SetActive (true);
		else
			lowAmmoWarning.gameObject.SetActive (false);
			
		if (isReloading)
			reloadingDisplay.SetActive (true);
		else
			reloadingDisplay.SetActive (false);


	}
	//fire method decrease round count and checks if reload is needed
	void Fire()
	{
		timer = 0;
		if (currentRound > 0) {
			currentRound -= 1;
			currentRoundText.text = currentRound.ToString ();
			guns [0].Shoot (bulletSpawn, fireEffect, fireSound);
		}

		else if (currentBullets !=0)
			StartCoroutine (ReloadDelay ());
		else
			Debug.Log ("No more ammo");
			
	}

	IEnumerator ReloadDelay()

	{
		isReloading = true;
		yield return new WaitForSeconds (2f);
		Reload ();
		isReloading = false;
	}

	//reloads current weapon
	public void Reload()
	{
		float bulletsNeeded = bulletsPerRound - currentRound;

		if (bulletsNeeded != 0&&currentBullets!=0) {
			
			if (currentBullets >= bulletsNeeded) {
				currentRound += bulletsNeeded;
				currentBullets -= bulletsNeeded;
			} else {
				currentRound += currentBullets;
				currentBullets = 0;
			}
		}
		 
		totalAmmoText.text = currentBullets.ToString ();
		currentRoundText.text = currentRound.ToString ();

	}

	public void MaxAmmo()
	{
		
		currentBullets = totalBullets;
		totalAmmoText.text = currentBullets.ToString ();
	}

	public void SwitchWeapon(int gunSlot)
	{
		currentBullets =  guns[gunSlot].totalbullets;
		bulletsPerRound = guns[gunSlot].bulletsperround;
		bulletCooldown =  guns[gunSlot].shootdelay;

		//set ammo
		//set round
		//activate gameObject
	}


}
