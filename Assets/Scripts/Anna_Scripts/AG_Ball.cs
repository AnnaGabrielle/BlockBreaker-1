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
	[Range(5,20)][SerializeField] float ag_constantVelocity = 15;
	[SerializeField] float ag_startballminX = -10;
	[SerializeField] float ag_startballMaxX = 10;
	[SerializeField] float ag_startballY = 15;

	//variables to calculate to change the velocity of the ball while playing
	float ag_velocity;
	[Range(0,1)][SerializeField] float ag_ballFactorX = 0.3f;
	[Range(0.5f,2)][SerializeField] float ag_ballFactorYmax = 0.5f;
	[Range(0.1f,2)][SerializeField] float ag_ballFactorYmin = 0.1f;
	float ag_ranfomFactor = 0.6f;

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
		//Debug.Log("velocity no update" + ag_MyRigidbody2D.velocity);
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
			ag_MyRigidbody2D.velocity = ag_constantVelocity * (ag_MyRigidbody2D.velocity.normalized);
			ag_ballLaunched = true;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision){
		Vector2 ag_velocityTweak = new Vector2(ag_ranfomFactor,ag_ranfomFactor);
		if(ag_ballLaunched){
			AudioClip ag_audioForBall = ag_BallAudios[Random.Range(0, ag_BallAudios.Length)];
			ag_AudioSource.PlayOneShot(ag_audioForBall);
			ag_MyRigidbody2D.velocity += ag_velocityTweak;
			Debug.Log("ag_MyRigidbody2D.velocity antes " + ag_MyRigidbody2D.velocity);
			ag_MyRigidbody2D.velocity = ag_constantVelocity * (ag_MyRigidbody2D.velocity.normalized);
			Debug.Log("ag_MyRigidbody2D.velocity depois" + ag_MyRigidbody2D.velocity);
		}
	}

}
