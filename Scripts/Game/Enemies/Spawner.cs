using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

	public Transform[] spawnPoints;
	GameObject[] numEnemies;
	public GameObject player;
	public Text waveText;

	int spawnLocation  ;
	int waveCounter;

	public float enemy1SpawnRate, enemy2SpawnRate, enemy3SpawnRate;


	public int enemiesPerWave;
	public int maxActiveEnemiesAllowed;
	public int enemyCounter;
	public bool waitingNextWave;

	void Awake()
	{
		spawnLocation = 0;
		waveCounter = 1;
		waitingNextWave = false;

		InvokeRepeating ("spawner",5,1);
	}

	public void spawner()
	{
		int temp;
		numEnemies = GameObject.FindGameObjectsWithTag ("Enemy");
		temp = numEnemies.Length;

		numEnemies = null;
		numEnemies = GameObject.FindGameObjectsWithTag ("Enemy2");
		temp += numEnemies.Length;

		numEnemies = null;
		numEnemies = GameObject.FindGameObjectsWithTag ("Enemy3");

		temp += numEnemies.Length;

		numEnemies = null;
	

	if (temp < maxActiveEnemiesAllowed && enemyCounter != enemiesPerWave && !waitingNextWave) {
			enemyCounter++;
			SpawnEnemy ();


		} else if (temp == 0 && enemyCounter == enemiesPerWave && !waitingNextWave) {
			waitingNextWave = true;
			StartCoroutine (ReadyNextWave ());
		}


	}
	public int Wave()
	{
		return this.waveCounter;
	}


	public void SpawnEnemy()
	{
		if (spawnLocation < spawnPoints.Length-1)
			spawnLocation++;
		else
			spawnLocation = 0;


		GameObject enemy = ObjectPool.SharedInstance.GetPooledObject (ChooseEnemy());
		enemy.transform.position = spawnPoints [spawnLocation].position;
		enemy.transform.rotation = spawnPoints [spawnLocation].rotation;
		enemy.SetActive (true);




	}
	IEnumerator ReadyNextWave()
	{
		yield return new WaitForSeconds (8f);
		waveText.text = waveCounter.ToString ();
		waitingNextWave = false;
		enemiesPerWave+=3;
		enemyCounter = 0;
		waveCounter++;

	}
	public double CurrentWave()
	{
		return this.waveCounter;
	}

	public string ChooseEnemy()
	{

		string enemyName;

		if (GenerateNumber () < enemy3SpawnRate)
			enemyName = "Enemy3";
		else if (GenerateNumber () < enemy2SpawnRate)
			enemyName = "Enemy";
		else
			enemyName = "Enemy2";

		return enemyName;


	}
	public float GenerateNumber()
	{
		float random = 0f;
		//using a loop to generate a random number a few times to ensure better results;
		for(int i = 0;i<10;i++)
			random = Random.Range (0f,101f);

		return random;
	}


}