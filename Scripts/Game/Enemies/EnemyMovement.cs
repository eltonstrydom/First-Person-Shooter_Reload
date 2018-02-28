using UnityEngine.AI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	NavMeshAgent nav;
	Transform player;
	State state;
	EnemyStats es;
	Animator anim;

	public EnemyRangeChecker rangeChecker;
	public float runSpeed;
	public AudioClip screech;
	public ParticleSystem rageEffect;

	bool canEnrage;
	bool canScreech;

	void Awake () {
		anim = GetComponentInChildren<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void OnEnable()
	{
		canScreech = true;
		rageEffect.Stop ();
		canEnrage = false;
		es = GetComponent<EnemyStats> ();
		nav.speed = runSpeed;
		StartCoroutine (CanEnrage ());
	}
	
	public enum State{
		
		Chasing,Attacking,Retreating,Idle,Dead,RageAttack,RageChase,
	}
	void Update () {
		CheckState ();
		switch (state) {

		case State.Chasing:
			ScreechSound ();
			nav.isStopped = false;
			anim.SetBool ("Attack",false);
			anim.SetBool ("Run",true);
			nav.destination = player.position;

			break;
		case State.Attacking: 
			
			nav.isStopped = true;
			anim.SetBool ("Attack",true);
			anim.SetBool ("Run",false);
			//play attack animation
			break;

		case State.Dead:
			nav.isStopped = true;
			anim.SetBool ("Attack", false);
			anim.SetBool ("Run", false);
			anim.SetBool ("Die",true);
			break;

		case State.RageAttack:
			nav.isStopped = true;
			anim.SetBool ("Attack", true);
			anim.SetBool ("Run", false);
			Debug.Log ("Rage Attack");
			rageEffect.Play ();
			//play attack animation
			break;

		case State.RageChase:
			nav.isStopped = false;
			anim.SetBool ("Attack", false);
			anim.SetBool ("Jump", true);
			anim.SetBool ("Run", false);
			Debug.Log ("Rage Chase");
			nav.destination = player.position;
			rageEffect.Play ();
			break;
		}



			
	}
	void CheckState()
	{
		if (es.GetEnemyHealth () > 0) {

			if (!rangeChecker.MeleeCheckRange ()) {
				if (canEnrage)
					state = State.RageChase;
				else
					state = State.Chasing;
			} else {
				if (canEnrage)
					state = State.RageAttack;
				else
					state = State.Attacking;
			}
				} else {
			state = State.Dead;
		}

	}


	IEnumerator CanEnrage()
	{
		yield return new WaitForSeconds (45f);
		{
			canEnrage = true;
			nav.speed = runSpeed * 2;
		}


	}

	void ScreechSound()
	{
		if ( Vector3.Distance (player.transform.position, transform.position) < 10 &&canScreech) {
			Debug.Log ("Screaming");
			canScreech = false;
			StartCoroutine (CanScreech ());
			AudioManager.audioManager.PlaySound (screech);
		}
	}

	IEnumerator CanScreech()
	{
		yield return new WaitForSeconds (3f);
		canScreech = true;
	}
}




