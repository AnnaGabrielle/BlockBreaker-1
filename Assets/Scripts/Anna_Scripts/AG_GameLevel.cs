using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AG_GameLevel : MonoBehaviour {

	//To show text and button when winning condition is met
	[SerializeField] GameObject ag_WinLevelText;
	[SerializeField] GameObject ag_NextLevel;
	[SerializeField] GameObject ag_BackMainMenu;
	[SerializeField] GameObject ag_BackgroundImageWin;

	//to disappear when winning condition is met
	[SerializeField] GameObject ag_Paddle;
	[SerializeField] GameObject ag_Ball;

	//quantity of blocks
	int ag_BreakableBlocks;
	int ag_MinionBlocks;
	int ag_UnbreakableBlocks;

	//Tags name
	public string ag_BreakableBlocksTAG;
	public string ag_UnbreakableBlocksTAG;
	public string ag_RedMinionTAG;
	public string ag_GreenMinionTAG;

	void Awake(){
		ag_BackMainMenu.SetActive(false);
		ag_NextLevel.SetActive(false);
		ag_WinLevelText.SetActive(false);
		ag_BackgroundImageWin.SetActive(false);
		ag_Ball.SetActive(true);
		ag_Paddle.SetActive(true);
	}
	public void AG_CountBreakableBlocks(){
		ag_BreakableBlocks++;
	}

	public void AG_CountMinionBlocks(){
		ag_MinionBlocks++;
	}

	public void AG_CountUnbreakableBlocks(){
		ag_UnbreakableBlocks++;
	}

	public void AG_BlockDestroyed(){
		ag_BreakableBlocks--;
		AG_WinConditional();
	}
	public void AG_MinionDestroyed(){
		ag_MinionBlocks--;
		AG_WinConditional();
	}

	public void AG_WinConditional(){
		if(ag_BreakableBlocks <=0 && ag_MinionBlocks<=0){
			ag_BackMainMenu.SetActive(true);
			ag_NextLevel.SetActive(true);
			ag_WinLevelText.SetActive(true);
			ag_BackgroundImageWin.SetActive(true);
			ag_Ball.SetActive(false);
			ag_Paddle.SetActive(false);

		}
	}
}
