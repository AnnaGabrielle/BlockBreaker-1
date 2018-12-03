using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Block : MonoBehaviour {

	[SerializeField] AudioClip ag_BreakAudio;
	[SerializeField] GameObject ag_SparklesVFX;
	[SerializeField] Sprite[] ag_hitSprite;

	int ag_MaxHit;
	AG_GameLevel ag_level;
	AG_GameStatus ag_GameStatus;

	//state reference
	int ag_TimeHit; 

	// Use this for initialization
	void Start () {
		ag_level = GameObject.FindGameObjectWithTag("AG_Level").GetComponent<AG_GameLevel>();
		ag_GameStatus = GameObject.FindGameObjectWithTag("AG_GameStatus").GetComponent<AG_GameStatus>();
		AG_CountingBlocks();
		ag_MaxHit = ag_hitSprite.Length + 1;

	}
	private void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(ag_BreakAudio, Camera.main.transform.position, 0.05f);
		AG_DestroyingBlocks();
	}

	private void AG_CountingBlocks(){
		var ag_Blocktag = gameObject.tag;
		if(ag_Blocktag == ag_level.ag_BreakableBlocksTAG){
			ag_level.AG_CountBreakableBlocks();
		}
		else if(ag_Blocktag == ag_level.ag_UnbreakableBlocksTAG){
			ag_level.AG_CountUnbreakableBlocks();
		}
		else{
			ag_level.AG_CountMinionBlocks();
		}
		
	}
	private void AG_DestroyingBlocks(){
		var ag_Blocktag = gameObject.tag;
		if(ag_Blocktag == ag_level.ag_BreakableBlocksTAG){
			ag_TimeHit++;
			if(ag_TimeHit >= ag_MaxHit){
				Destroy(gameObject);
				ag_level.AG_BlockDestroyed();
				ag_GameStatus.AG_AddToScore_Block();
			}
			else{
				AG_ShowNextSprite();
			}
			AG_TriggerVFX(ag_SparklesVFX);	
		}
		else {
			if(ag_Blocktag == ag_level.ag_GreenMinionTAG){
				ag_TimeHit++;
				if(ag_TimeHit >= ag_MaxHit){
					Destroy(gameObject);
					ag_GameStatus.AG_AddToScore_Minion();
					ag_level.AG_MinionDestroyed();
				}
				else{
					AG_ShowNextSprite();
				}
				AG_TriggerVFX(ag_SparklesVFX);
			}
			else{
				ag_TimeHit++;
				if(ag_TimeHit >= ag_MaxHit){
					Destroy(gameObject);
					ag_GameStatus.AG_AddToScore_Minion();
					ag_level.AG_MinionDestroyed();
				}
				else{
					AG_ShowNextSprite();
				}
				AG_TriggerVFX(ag_SparklesVFX);
			}
		}

	}
	private void AG_TriggerVFX(GameObject particleVFX){
		GameObject ag_sparkles = Instantiate(particleVFX, transform.position, transform.rotation);
		Destroy(ag_sparkles,0.2f);
	}

	private void AG_ShowNextSprite(){
		int spriteIndex = ag_TimeHit-1;
		if(ag_hitSprite[spriteIndex] != null){
			GetComponent<SpriteRenderer>().sprite = ag_hitSprite[spriteIndex];
		}
		else{
			Debug.LogError("Block sprite is missing from array in " + gameObject.name);
		}
	}
}
