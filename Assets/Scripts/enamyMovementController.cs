using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enamyMovementController : MonoBehaviour {

	public float enamySpeed;

	Animator enamyAnimator;

	//facing
	public GameObject enamyGraphic;
	bool canFlip=true;
	bool facingRight=false;
	float flipTime=5f;
	float nextFlipChance=0f;

	//attacking
	public float chargeTime;
	float startChargeTime;
	bool charging;
	Rigidbody2D enamyRB;

	// Use this for initialization
	void Start () {
		enamyAnimator = GetComponentInChildren<Animator> ();
		enamyRB = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance) {
			if (Random.Range (0, 10) >= 5)flipFacing ();
		    nextFlipChance = Time.time + flipTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			if (facingRight && other.transform.position.x < transform.position.x) {
				flipFacing ();
			} else if (!facingRight && other.transform.position.x > transform.position.x) {
				flipFacing ();
			}
			canFlip = false;
			charging = true;
			startChargeTime = Time.time + chargeTime;
			
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player") {
			if (startChargeTime < Time.time)
				{
				if (!facingRight) enamyRB.AddForce (new Vector2 (-2, 0) * enamySpeed);
				else enamyRB.AddForce (new Vector2 (2, 0) * enamySpeed);
				enamyAnimator.SetBool ("isCharging", charging);

			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			canFlip = true;
			charging = false;
			enamyRB.velocity = new Vector2 (0f,0f);
			enamyAnimator.SetBool ("isCharging", charging);
		}
	}

	void flipFacing(){
		if (!canFlip)return;
		float facingX = enamyGraphic.transform.localScale.x;
		facingX *= -1f;
		enamyGraphic.transform.localScale = new Vector3 (facingX, enamyGraphic.transform.localScale.y, enamyGraphic.transform.localScale.z);
		facingRight =!  facingRight;
	}
  }

