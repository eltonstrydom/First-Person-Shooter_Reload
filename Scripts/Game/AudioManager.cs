using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public float sfxVolume;  
	public float backTrackVolume; 
	AudioSource audioSource;

	public GameObject audioSourceSFX,playerRunningSFX,playerWalkingSFX,playerExhaustedSFX;
	public static AudioManager audioManager;

	public AudioClip backTrack1;

	void Awake () 
	{
		audioManager = this;
		audioSource = GetComponent<AudioSource> ();
		//PlayBackTrack (backTrack1);
		DontDestroyOnLoad(this.gameObject);
	}

	public void PlaySound(AudioClip audioClip)
	{
		audioSourceSFX.GetComponent<AudioSource>().PlayOneShot (audioClip);   //Play sfx
	}

	public void PlayBackTrack(AudioClip audioClip)
	{
		audioSource.PlayOneShot (audioClip);                                 //Play background music
	}
	//Personal AS for player sfx
	public void PlayRunningSound()
	{
		if(!playerRunningSFX.GetComponent<AudioSource>().isPlaying)
		playerRunningSFX.GetComponent<AudioSource>().Play();   
	}
	public void PlayWalkingSound()
	{
		if(!playerWalkingSFX.GetComponent<AudioSource>().isPlaying)
			playerWalkingSFX.GetComponent<AudioSource>().Play();   
	}
	public void PlayExhaustedBreathing()
	{
		if(!playerExhaustedSFX.GetComponent<AudioSource>().isPlaying)
			playerExhaustedSFX.GetComponent<AudioSource>().Play();   
	}

	public void StopRunningSound()
	{
		playerRunningSFX.GetComponent<AudioSource>().Stop();   
	}
	public void StopWalkingSound()
	{
		playerRunningSFX.GetComponent<AudioSource>().Stop();   
	}
	public void StopExhaustedBreathing()
	{
		playerExhaustedSFX.GetComponent<AudioSource>().Stop();   
	}



}
