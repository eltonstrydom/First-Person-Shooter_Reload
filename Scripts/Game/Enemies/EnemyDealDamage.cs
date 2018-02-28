using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour {

	public float damage;
	float timer;
	float attackCooldown;
	public AudioClip attackSound;
	public EnemyStats enemyStat;
	void Awake()
	{
		attackCooldown = 0.5f;

	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && timer >= attackCooldown&&enemyStat.GetEnemyHealth()>0) {
			timer = 0;
			AudioManager.audioManager.PlaySound (attackSound);
			other.gameObject.GetComponent < PlayerHealth> ().TakeDamage (damage);
		}
			
	}

	void Update()
	{
		timer += Time.deltaTime;
	}
}
