using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	public float maxPlayerHealth;
	float currentPlayerHealth;
	public Slider healthSlider;
	bool getDamage;
	bool canPlayHitSound;
	UIManager ui;
	public AudioClip getHitSound;
	public Image bloodImage;
	// Use this for initialization


	void Start () {
		canPlayHitSound = true;
		ui = GameObject.FindGameObjectWithTag ("Managers").GetComponent<UIManager>();
		currentPlayerHealth = maxPlayerHealth;
		healthSlider.value = currentPlayerHealth;
	}
	

	//player take damage method
	public void TakeDamage(float amount)
	{
		this.currentPlayerHealth -= amount;
		HitSoundManager ();
		getDamage = true;
		healthSlider.value = currentPlayerHealth/maxPlayerHealth;
		if (this.currentPlayerHealth <= 0) {
			
			Debug.Log ("PlayerDead");
			ui.DisplayEndGame ();
		}
	}


	void Update()
	{
		if (getDamage)
		{
			
			Color Opaque = new Color(1, 0, 0, 0.1f);
			bloodImage.color = Color.Lerp(bloodImage.color, Opaque, 20 * Time.deltaTime);
			StartCoroutine (SetDamageFalse ());
		}
		if (!getDamage)
		{
			Color Transparent = new Color(1, 1, 1, 0);
			bloodImage.color = Color.Lerp(bloodImage.color, Transparent, 20 * Time.deltaTime);
		}

		if (!getDamage&&currentPlayerHealth<maxPlayerHealth) {
			currentPlayerHealth += 0.2f;
			healthSlider.value = currentPlayerHealth/maxPlayerHealth;
		}

	}





	void HitSoundManager()

	{
		if (canPlayHitSound) {
			AudioManager.audioManager.PlaySound (getHitSound);
			canPlayHitSound = false;
		} else
			StartCoroutine (WaitForHitSound ());
		
		
	}
	IEnumerator SetDamageFalse()
	{
		yield return new WaitForSeconds (0.2f);
		getDamage = false;
	}

	IEnumerator WaitForHitSound()
	{
		yield return new WaitForSeconds (0.4f);
		canPlayHitSound = true;
	}


}
