using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_AK47BulletBehaviour : MonoBehaviour {

	float damageAmount;

	void Awake()
	{
		damageAmount = 40f;
	}
	void OnEnable()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * 160;
		StartCoroutine (Disable ());

	}

	IEnumerator Disable()
	{

		yield return new WaitForSeconds (1f);
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy"||other.tag == "Enemy2"||other.tag == "Enemy3"&&other.gameObject.GetComponent<EnemyStats> ().GetEnemyHealth()>0) {


			other.gameObject.GetComponent<EnemyStats> ().TakeDamage (damageAmount);
			Debug.Log ("Damage done");
		}
		this.gameObject.SetActive (false);
	}
}
