using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMain : MonoBehaviour {
	
	private float totalBullets;
	private float bulletsPerRound { get; set;}
	private float reloadTime      { get; set;}
	private float shootDelay      { get; set;}

	public GunMain(float tb,float bpr,float rt,float sd)
	{
		this.totalBullets = tb;
		this.bulletsPerRound = bpr;
		this.reloadTime = rt;
		this.shootDelay = sd;
	}
	public virtual void Shoot(Transform bulletSpawn,ParticleSystem fireEffect,AudioClip fireSound)
	{
		Debug.Log ("There is no ability logic here");
	}
	public float totalbullets
	{
		get {return totalBullets;}
	}
	public float bulletsperround
	{
		get {return bulletsPerRound;}
	}
	public float reloadtime
	{
		get {return reloadTime;}
	}
	public float shootdelay
	{
		get {return shootDelay;}
	}

}
