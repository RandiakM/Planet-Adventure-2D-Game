using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public float fullHealth;
	public GameObject deathFX;
	public AudioClip playerHurt;

	public restartGame theGameManager;

	float currentHealth;

	playerController controlMovement;

	public AudioClip playerDeathSound;
	AudioSource playerAs;

	//HUD variables
	public Slider healthSlider;
	public Image damageScreen;
	public Text gameOverScreen;
	public Text winGameScreen;

	bool damaged = false;
	Color damagedColour=new Color(0f,0f,0f,0.5f);
	float smoothColour=5f;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<playerController> ();

		//HUD Initialization
		healthSlider.maxValue=fullHealth;
		healthSlider.value = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if (damaged) {
			damageScreen.color = damagedColour;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColour*Time.deltaTime);
		}
		damaged = false;

		playerAs = GetComponent<AudioSource> ();
		
	}

	public void addDamage(float damage){
		if (damage <= 0)return;
		currentHealth -= damage;

		//playerAs.clip = playerHurt;
		//playerAs.Play ();
		playerAs.PlayOneShot(playerHurt);

		healthSlider.value = currentHealth;
		damaged = true;
			
		if (currentHealth <= 0) {
			makeDead();
		}
	}

	public void addHealth(float healthAmount){
		currentHealth += healthAmount;
		if (currentHealth > fullHealth) currentHealth = fullHealth;
		healthSlider.value = currentHealth;
	}

	public void makeDead(){
		Instantiate (deathFX, transform.position, transform.rotation);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (playerDeathSound, transform.position);
		damageScreen.color = damagedColour;

		Animator gameOverAnimator = gameOverScreen.GetComponent<Animator> ();
		gameOverAnimator.SetTrigger ("gameOver");
		theGameManager.restartTheGame ();
	}

	public void winGame(){
		Destroy (gameObject);
		theGameManager.restartTheGame ();
		Animator winGameAnimator = winGameScreen.GetComponent<Animator> ();
		winGameAnimator.SetTrigger ("gameOver");
	}
}
