using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sporeController : MonoBehaviour {

	public float sporeSpeedHigh;
	public float sporeSpeedLow;
	public float sporeAngle;
	public float sporeTorqeAngle;

	Rigidbody2D sporeRB;

	// Use this for initialization
	void Start () {
		sporeRB = GetComponent<Rigidbody2D> ();
		sporeRB.AddForce (new Vector2 (Random.Range (-sporeAngle, sporeAngle), Random.Range (sporeSpeedLow, sporeSpeedHigh)), ForceMode2D.Impulse);
		sporeRB.AddTorque ((Random.Range (-sporeTorqeAngle, sporeTorqeAngle)));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
