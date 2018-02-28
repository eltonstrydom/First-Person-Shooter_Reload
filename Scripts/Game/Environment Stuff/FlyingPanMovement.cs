using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPanMovement : MonoBehaviour {
	public Transform location,beginPosition;
	public float speed;
	public bool playerOnPan;
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (playerOnPan) {
			
			transform.position = Vector3.MoveTowards (transform.position, location.position, step);


		}
		else
			transform.position = Vector3.MoveTowards (transform.position, beginPosition.position, step);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			playerOnPan = true;
		
	}

	void OnTriggerExit(Collider other)
	{
		//if (other.tag == "Player")
		//	playerOnPan = false;
	}
}
