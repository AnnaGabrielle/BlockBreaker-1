using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Paddle : MonoBehaviour {
	[SerializeField] float ag_screenWidthInUnits=16f;
	[SerializeField] float ag_minX = 1.95f;
	[SerializeField] float ag_maxX = 14.33f;

	AG_GameStatus ag_gameStatus;
	AG_Ball ag_Ball;

	// Use this for initialization
	void Start () {
		ag_gameStatus = GameObject.FindGameObjectWithTag("AG_GameStatus").GetComponent<AG_GameStatus>();
		ag_Ball = GameObject.FindGameObjectWithTag("AG_Ball").GetComponent<AG_Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		AG_MoveWithMouse();
		
	}

	public void AG_MoveWithMouse(){
		Vector2 ag_PaddlePosition = new Vector2(transform.position.x,transform.position.y);
		ag_PaddlePosition.x = Mathf.Clamp(AG_GetXPos(), ag_minX, ag_maxX);
		transform.position = ag_PaddlePosition;

	}

	private float AG_GetXPos(){
		if(ag_Ball.ag_ballLaunched){
			if(ag_gameStatus.AG_IsAutoPlayEnabled()){
				return ag_Ball.transform.position.x;
			}
			else{
				return Input.mousePosition.x/Screen.width * ag_screenWidthInUnits;
			}
		}
		else{
			return Input.mousePosition.x/Screen.width * ag_screenWidthInUnits;
		}
	}
}
