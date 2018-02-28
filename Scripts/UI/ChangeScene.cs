using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour{
	
	public string sceneName;
	//specify scene in editor
	public GameObject loadingScreen;
	AsyncOperation async;

	public void LoadScene()
	{
		StartCoroutine (LoadingScreen ());
	}

	IEnumerator LoadingScreen()
	{
		loadingScreen.SetActive (true);
		async = SceneManager.LoadSceneAsync (sceneName);
		async.allowSceneActivation = false;

		while (async.isDone == false) {
			if (async.progress == 0.9f)
				async.allowSceneActivation = true;

			yield return null;
		}
	}
	/*
public void  LoadScene()

	{
		SceneManager.LoadScene (sceneName);
	}
*/

}
