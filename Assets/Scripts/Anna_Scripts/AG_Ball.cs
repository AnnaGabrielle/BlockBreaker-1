using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Ball : MonoBehaviour {

	[SerializeField] AG_Paddle ag_Paddle;
	Vector2 ag_paddleToBallVector;
	int ag_MouseButton = 0; //left button

	[SerializeField] AudioClip[] ag_BallAudios;


	public bool ag_ballLaunched = false; //verify if ball has been lauched (game started)


	//vector for ball when launched (direction to be launched)
	[SerializeField] float ag_startballminX = 2;
	[SerializeField] float ag_startballMaxX = 10;
	[SerializeField] float ag_startballY = 15;

	//variables to calculate to change the velocity of the ball while playing
	float ag_velocity;
	[Range(0,2)][SerializeField] float ag_ballFactor = 0.8f;

	//Cached component reference
	AudioSource ag_AudioSource;
	Rigidbody2D ag_MyRigidbody2D;


	// Use this for initialization
	void Start () {
		ag_ballLaunched = false;
		AG_DistancePaddleAndBall();
		ag_AudioSource = GetComponent<AudioSource>();
		ag_MyRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ag_ballLaunched){	
			AG_LockBallToPaddle();
			AG_LaunchBallOnClick();
		}
	}

	private void AG_DistancePaddleAndBall(){
		ag_paddleToBallVector = transform.position - ag_Paddle.transform.position;
	}

	private void AG_LockBallToPaddle(){
		Vector2 ag_PaddlePosition = new Vector2(ag_Paddle.transform.position.x, ag_Paddle.transform.position.y);
		transform.position = ag_PaddlePosition + ag_paddleToBallVector;
	}

	private void AG_LaunchBallOnClick(){
		if(Input.GetMouseButtonDown(ag_MouseButton)){
			ag_MyRigidbody2D.velocity = new Vector2 (Random.Range(ag_startballminX, ag_startballMaxX), ag_startballY);
			ag_ballLaunched = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		Vector2 ag_velocityTweak = new Vector2(AG_CalcuteVelocity(ag_startballMaxX), AG_CalcuteVelocity(ag_startballY));
		if(ag_ballLaunched){
			AudioClip ag_audioForBall = ag_BallAudios[Random.Range(0, ag_BallAudios.Length)];
			ag_AudioSource.PlayOneShot(ag_audioForBall);
			ag_MyRigidbody2D.velocity += ag_velocityTweak;
		}
	}

	private float AG_CalcuteVelocity(float start_variable){ //method for the ball not be too fast
		float aux_variable = Random.Range(0, ag_ballFactor); //variable to help calculate
		if(aux_variable>=(start_variable+10*ag_ballFactor)){
			ag_velocity = aux_variable;
		}
		else{
			ag_velocity = start_variable;
		}
		return aux_variable;
		
	}

}
