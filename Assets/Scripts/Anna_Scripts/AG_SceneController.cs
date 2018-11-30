using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AG_SceneController : MonoBehaviour {
	public void LoadTheScene(string name){
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
	
	//Method to quit the game when button of quit is clicked
	public void QuitTheGame(){
		Application.Quit();
	}

	public void AG_LoadMenu(string name){
		SceneManager.LoadScene(name, LoadSceneMode.Single);
		var ag_GameStatus = GameObject.FindGameObjectWithTag("AG_GameStatus").GetComponent<AG_GameStatus>();
		ag_GameStatus.AG_ResetGame();
	}
}
