using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float minimumX = -60f;
	public float maximumX =60f;
	public float minimumY = -360f;
	public float maximumY = 360f;

	public float sensitivityX = 15f;
	public float sensitivityY = 15f;

	public Camera cam;
	public float moveSpeed;

	float rotationY = 0f;
	float rotationX = 0f;

	public Vector3 offset;



	void Start () {
		Cursor.lockState = CursorLockMode.Locked;

	

	}
	

	void LateUpdate () {
		if (Time.timeScale == 0f)
			return;
		rotationX += Input.GetAxis ("Mouse Y") * sensitivityY;

		rotationY += Input.GetAxis ("Mouse X") * sensitivityY;

		rotationX = Mathf.Clamp (rotationX,minimumX,maximumX);





		transform.localEulerAngles = new Vector3 (0,rotationY,0);



		cam.transform.localEulerAngles = new Vector3 (-rotationX,rotationY,0);


		cam.transform.position = transform.position + offset;

		//Vector3 newPos = new Vector3(transform.position.x, posY, transform.position.z);
	//	transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
	}




}




