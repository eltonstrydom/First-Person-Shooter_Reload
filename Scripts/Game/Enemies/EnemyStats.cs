using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyStats : MonoBehaviour {
	public float enemyMaxHealth;
	float enemyCurrentHealth;
	float scoreValue;
	public GameObject body;
	CapsuleCollider cap;

	AudioClip bloodSound;
	public ParticleSystem bloodSpatter;
	bool isDead;
	// Use this for initialization
	void Start()
	{
		bloodSound = Resources.Load<AudioClip> ("Sounds/BloodSound1");
	}

	void Awake()
	{
		cap = body.GetComponent<CapsuleCollider>();

		scoreValue = 5;
	}
	void OnEnable () {
		isDead = false;
		enemyCurrentHealth = enemyMaxHealth;
		cap.enabled = true;

	}
	
	public void TakeDamage(float damageAmount)
	{
		enemyCurrentHealth -= damageAmount;
		bloodSpatter.Play() ;
		AudioManager.audioManager.PlaySound (bloodSound);



		if (enemyCurrentHealth <= 0&&!isDead) {
			Debug.Log ("Enemy is Dead");
			cap.enabled = false;
			isDead = true;
			PlayerScore.SharedInstanceScore.IncreaseKillCount ();
			PlayerScore.SharedInstanceScore.IncreaseScore (scoreValue);
			StartCoroutine (DeathDelay());
		}
	}

	public float GetEnemyHealth()
	{
		return enemyCurrentHealth;
	}

	IEnumerator DeathDelay()
	{
		yield return new WaitForSeconds (2f);
		this.gameObject.SetActive (false);

	}
}
