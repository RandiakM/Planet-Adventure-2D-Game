using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketHit : MonoBehaviour {

	public float weponDamage;

	projectileController myPC;

	public GameObject explotionEffect;
	// Use this for initialization
	void Awake () {
		myPC = GetComponentInParent<projectileController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myPC.removeForce ();
			Instantiate (explotionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
			if (other.tag == "Enamy") {
				enamyHealth hurtEnamy = other.gameObject.GetComponent<enamyHealth> ();
				hurtEnamy.addDamage (weponDamage);
			}
		}
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myPC.removeForce ();
			Instantiate (explotionEffect, transform.position, transform.rotation);
			Destroy (gameObject);
			if (other.tag == "Enamy") {
				enamyHealth hurtEnamy = other.gameObject.GetComponent<enamyHealth> ();
				hurtEnamy.addDamage (weponDamage);
			}
		}
	}
}
