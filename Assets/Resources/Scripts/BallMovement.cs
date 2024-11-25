using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	public float movementSpeed;
	public float extraSpeedPerhit;
	public float maxExtraSpeed;

	int hitCounter=0;

	// Use this for initialization
	void Start () {
		StartCoroutine (this.StartBall ());
		
	}

	void PositionBall(bool isStartingPlayer1)
	{
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		if (isStartingPlayer1) {
			this.gameObject.transform.localPosition = new Vector3 (-100, 0, 0);
		} else {
			this.gameObject.transform.localPosition = new Vector3 (100, 0, 0);
		}
	}
	public IEnumerator StartBall(bool isStartingPlayer1 = true)
	{
		this.PositionBall (isStartingPlayer1);
		this.hitCounter = 0;
		yield return new WaitForSeconds(2);
		if (isStartingPlayer1)
			this.Moveball (new Vector2 (-1, 0));
		else
			this.Moveball (new Vector2 (1, 0));
	}


	public void Moveball(Vector2 dir)
	{
		dir = dir.normalized;
		float speed = this.movementSpeed + this.hitCounter + this.extraSpeedPerhit;
		Rigidbody2D rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
		rigidbody2d.velocity = dir * speed;
	}

	public void InreasedHitCounter(){
		if (this.hitCounter * this.extraSpeedPerhit <= this.maxExtraSpeed) {this.hitCounter++;}
	}
	

}
