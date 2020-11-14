using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManage : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		Scene activeScene = SceneManager.GetActiveScene();
		string scene = activeScene.name;

		if (Input.GetAxis("Submit") == 1 && scene == "Start") {
			SceneManager.LoadScene("Instructions");
		}

		if (Input.GetAxis("Submit") == 1 && scene == "Instructions") {
			Destroy(GameObject.Find("backgroundMusic"));
			SceneManager.LoadScene("Play");
		}

		if (Input.GetAxis("Submit") == 1 && scene == "Death") {
			Destroy(GameObject.Find("backgroundMusicGeneral"));
			SceneManager.LoadScene("Start");
		}

		else if (Input.GetAxis("Submit") == 1 && scene == "Victory") {
			Destroy(GameObject.Find("backgroundMusicGeneral"));
			SceneManager.LoadScene("Start");
		}
	}

	public void transitionPlay(){
		SceneManager.LoadScene("Play");
	}

	public void transitionStart(){
		SceneManager.LoadScene("Start");
	}

}
