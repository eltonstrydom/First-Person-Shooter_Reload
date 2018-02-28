using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;


	float tempSpeed;
	float runningCD,timeAllowedToRun;
	float runningTime;
	bool canRun;
	bool canJump;
	float jumpCD;
	Rigidbody rb;
	Vector3 moveDirection;

	void Awake () {

		canRun = true;
		canJump = true;

		jumpCD = 0.7f;
	    runningCD = 5f;
		timeAllowedToRun = 3f;
		rb = GetComponent<Rigidbody> ();
	}
	

	void Update () {
		//direction
		float horizontalMovement = Input.GetAxisRaw ("Horizontal");
		float verticalMovement = Input.GetAxisRaw ("Vertical");


		//control running status
		if (Input.GetKey (KeyCode.LeftShift)&&canRun) {
			runningTime += Time.deltaTime;
			if (runningTime >= timeAllowedToRun) {
				runningTime = 0;
				canRun = false;
				StartCoroutine (SetRunningState());
			}

			tempSpeed = speed *2;

		}
			
		else
			tempSpeed = speed;
				
		moveDirection = (horizontalMovement*transform.right+verticalMovement*transform.forward).normalized;

		SoundHandler (horizontalMovement,verticalMovement);

	}

	void FixedUpdate()
	{
		Move ();

		//jump
		if (Input.GetKeyDown (KeyCode.Space) && canJump) {
			rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
			canJump = false;
			StartCoroutine (SetJumpState());
		}


	}

	void Move()
	{
		Vector3 yVelFixer = new Vector3 (0,rb.velocity.y,0);
		rb.velocity = moveDirection * tempSpeed * Time.deltaTime;
		rb.velocity += yVelFixer;

	}

	void SoundHandler(float horizontalMovement,float verticalMovement)
	{
		if ((horizontalMovement > 0 || verticalMovement > 0) && Input.GetKey (KeyCode.LeftShift)&&canRun) {
			//AudioManager.audioManager.PlayRunningSound ();
			//AudioManager.audioManager.StopWalkingSound ();
			AudioManager.audioManager.PlayWalkingSound ();
			AudioManager.audioManager.StopRunningSound ();
			AudioManager.audioManager.PlayExhaustedBreathing ();
		
		} else if (horizontalMovement > 0 || verticalMovement > 0) {
			AudioManager.audioManager.PlayWalkingSound ();
			AudioManager.audioManager.StopRunningSound ();
			AudioManager.audioManager.StopExhaustedBreathing ();

		}
		else if (horizontalMovement <= 0 && verticalMovement <= 0) {
			AudioManager.audioManager.StopRunningSound ();
			AudioManager.audioManager.StopWalkingSound ();
			AudioManager.audioManager.StopExhaustedBreathing ();
		
		}
		
			
	}

	IEnumerator SetRunningState()
	{
		yield return new WaitForSeconds(runningCD);
		canRun = true;
	}

	IEnumerator SetJumpState()
	{
	
		yield return new WaitForSeconds (jumpCD);
		canJump = true;}
}
