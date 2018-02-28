using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_AK47 : GunMain {

	private const float totalBullets = 250f;
	private const float bulletsPerRound = 50f;
	private const float reloadTime= 2f;
	private const float shootDelay = 0.15f;

	public Gun_AK47():base(totalBullets,bulletsPerRound,reloadTime,shootDelay)
	{

	}

	public override void Shoot(Transform bulletSpawn,ParticleSystem fireEffect,AudioClip fireSound)
	{
		  
	        AudioManager.audioManager.PlaySound (fireSound);
		    fireEffect.Play ();
			GameObject bullet = ObjectPool.SharedInstance.GetPooledObject ("Bullet1");
			bullet.transform.position = bulletSpawn.position;
			bullet.transform.rotation = bulletSpawn.rotation;
			bullet.SetActive (true);
			//bullet.GetComponent<Rigidbody> ().velocity = transform.forward * 80;

	}


}
