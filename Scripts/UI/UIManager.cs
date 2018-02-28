using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public bool isPaused;
	public bool endGame;
	public GameObject pauseMenu;
	public GameObject endGameMenu;

	void Start () {
		endGame = false;
		isPaused = false;
	}
	

	void Update () {
		
		if (Input.GetKeyDown ("escape") && !isPaused&&!endGame) {
		    isPaused = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		
		//show pause menu
		}
		else if(Input.GetKeyDown ("escape") && isPaused) {
	        isPaused = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			//no longer paused
		}

		if (isPaused) {
			pauseMenu.gameObject.SetActive (isPaused);
			Time.timeScale = 0f;
		} else if (endGame) {
			Time.timeScale = 0f;

		} else {
			pauseMenu.gameObject.SetActive (isPaused);
			Time.timeScale = 1f;
		}
			
		}

	//changes pause state
	public void PauseGame()
	{
		if (isPaused) {
			isPaused = false;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		else 
		{
			isPaused = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

		}
			
	}
	//display end game menu
	public void DisplayEndGame()
	{
		endGameMenu.SetActive (true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		endGame = true;
	}



}
