using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enamyHealth : MonoBehaviour {

	public float enamyMaxHealth;

	public GameObject enamyDeathFX;
	public Slider enamySlider;

	public bool drops;
	public GameObject theDrop;

	public AudioClip deathKnell;

	float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = enamyMaxHealth;
		enamySlider.maxValue = currentHealth;
		enamySlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addDamage(float damage){
		currentHealth -= damage;
		enamySlider.value = currentHealth;

		if (currentHealth <= 0) makeDead();
	}

	void makeDead(){
		Destroy (gameObject.transform.parent.gameObject);
		AudioSource.PlayClipAtPoint (deathKnell, transform.position);
		Instantiate (enamyDeathFX, transform.position, transform.rotation); 
		if (drops) Instantiate (theDrop, transform.position, transform.rotation);
			
	}
}
