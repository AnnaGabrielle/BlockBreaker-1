using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_GameStatus : MonoBehaviour {

	[Range(0.1f,3)][SerializeField] float ag_GameSpeed =0.8f; //1 is normal speed

	int ag_currentScore = 0;
	[SerializeField] int ag_pointPerBlock = 10;
	[SerializeField] int ag_pointPerMinion = 20;

	[SerializeField] bool ag_autoPlayEnabled;

	private void Awake(){
		int ag_gameStatusCount = GameObject.FindGameObjectsWithTag("AG_GameStatus").Length;
		if(ag_gameStatusCount > 1){
			gameObject.SetActive(false);
			Destroy(gameObject);
		}
		else{
			DontDestroyOnLoad(gameObject);
		}
	}
	
	void Update () {
		Time.timeScale = ag_GameSpeed;
	}

	//Score
	public void AG_AddToScore_Block(){
		ag_currentScore = ag_currentScore + ag_pointPerBlock;
	}
	public void AG_AddToScore_Minion(){
		ag_currentScore = ag_currentScore + ag_pointPerMinion;
	}

	public void AG_ResetGame(){
		Destroy(gameObject);
	}

	public bool AG_IsAutoPlayEnabled(){
		return ag_autoPlayEnabled;
	}
}
