using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_LoseCollider : MonoBehaviour {
	
	[SerializeField] string ag_loseScreen;
	private void OnTriggerEnter2D(Collider2D collision){
		SceneManager.LoadScene(ag_loseScreen);
	}
}
