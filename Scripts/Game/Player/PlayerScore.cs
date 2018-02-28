using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {
	public static PlayerScore SharedInstanceScore;
	public Text scoreText;
	public Text killCountText;
	float currentScore;
	float totalScore;
	float killCount;
	// Use this for initialization
	void Start () {
		currentScore = 0;
		totalScore = 0;
		SharedInstanceScore = this;
	}

	public void IncreaseScore(float score)
	{
		currentScore += score;

		totalScore += score;
		scoreText.text = currentScore.ToString();
	}
	public void DecreaseScore(float score)
	{
		currentScore -= score;
		scoreText.text = currentScore.ToString();
	}

	public float GetCurrentScore()
	{
		return this.currentScore;
	}

	public void IncreaseKillCount()
	{
		killCount += 1;
		killCountText.text = killCount.ToString ();
	}

	

}
