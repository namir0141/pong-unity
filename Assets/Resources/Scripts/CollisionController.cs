 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	public BallMovement ballMovement;
	public ScoreController scoreController;

	void BonuceFromRacket(Collision2D c)
	{
		Vector3 ballPosition = this.transform.position;
		Vector3 racketPosition = c.gameObject.transform.position;

		float racketHIGHT = c.collider.bounds.size.y;

		float x;
		if (c.gameObject.name == "Racket Platyer 1") {
			x = 1;
		} else {
			x = -1;
		}
		float y = (ballPosition.y - racketPosition.y) / racketHIGHT;
		this.ballMovement.InreasedHitCounter();
		this.ballMovement.Moveball (new Vector2 (x, y));
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Racket Platyer 1" || collision.gameObject.name == "Racket Platyer 2") {
			this.BonuceFromRacket (collision);

		} 
		else if(collision.gameObject.name == "WallLeft")
		{
			Debug.Log ("Collion with wallleft");
			this.scoreController.GoalPlayer2 ();
			StartCoroutine (this.ballMovement.StartBall (true));
		}
		else if(collision.gameObject.name == "WallRight")
		{
			Debug.Log ("Collion with wallright");
			this.scoreController.GoalPlayer1 ();
			StartCoroutine (this.ballMovement.StartBall (false));
		}
			
	}
}
