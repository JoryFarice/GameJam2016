/* This is a game controller script it holds most of the variables on the game
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public int whichPlayer;
	//public GameObject whiteFlag;

	//public AudioClip hitSound;
	public int playerHP;
	public int playerScore;
	public int playerAmmo;
	public int timer;
	public float waitTime = 1f;

	private Text scoreText;
	private Slider healthBar;
	private Text ammoText;
	private Text timerText;

	private GameController control;

	/*
	public AudioClip Splat;
	public AudioClip Music;

	AudioSource sound;
*/

	public void Awake()
	{
		if(control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this)
		{
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start ()
	{
		playerHP = 10;
		//player2HP = 10;
		playerAmmo = 25;
		//playerRespawn();
		//	sound = GetComponent<AudioSource>();

		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
		healthBar.maxValue = playerHP;
		scoreText.text = ("Score: " + playerScore);
		timerText = GameObject.Find("Timer").GetComponent<Text>();
		}

	// Update is called once per frame
	void Update ()
	{
		healthBar.value = playerHP;
		waitTime -= Time.deltaTime;
		if(waitTime <= 0)
		{
		timer -= 1;
		waitTime = 1;
		}

		timerText.text = ("Time: " + timer);
		scoreText.text = ("Score: " + playerScore);

		#region player dies
		if (playerHP <= 0) {
			//playerRespawn();
			//UpdateHealthBar1();

			playerHP = 10;
		}

		#endregion


		//Application.LoadLevel (3);

	}

	void FixedUpdate ()
	{
		//FindUIComponents();
	}

	#region methods

	public void playerHPDown ()
	{
		playerHP -= 1;
		//UpdateHealthBar1();
		//sound.Play();
		//Debug.Log("Audio");
	}



	public void playerRespawn1 ()
	{
		GameObject.FindGameObjectWithTag ("Player1").transform.position = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
	}

	public void playerRespawn2 ()
	{
		GameObject.FindGameObjectWithTag ("Player2").transform.position = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
	}

	public void playerRespawn3 ()
	{
		GameObject.FindGameObjectWithTag ("Player3").transform.position = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
	}

	public void playerScoreUp ()
	{
		playerScore += 2;
		//UpdateScoreText1();
	}



	/*public void fell ()
	{
		if (GameObject.FindGameObjectWithTag ("Player1").transform.position.y <= -60) {
			//Debug.Log("I should respawn");
			playerRespawn1 ();
		}

		if (GameObject.FindGameObjectWithTag ("Player2").transform.position.y <= -60) {
			//Debug.Log("I should respawn");
			playerRespawn2 ();
		}

		if (GameObject.FindGameObjectWithTag ("Player3").transform.position.y <= -60) {
			//Debug.Log("I should respawn");
			playerRespawn3 ();
		}


	}*/

	/*public void player1AmmoUp()
	{
		playerAmmo = 25;
		//UpdateAmmoText1();
	}



	public void player1AmmoDown()
	{
		playerAmmo -= 1;
		//UpdateAmmoText1();
	}*/

	#endregion


	/*
	#region UI methods
	public void FindUIComponents() {

		if (flag1 == null) {
			flag1 = GameObject.Find("FlagIcon1").GetComponent<Image>();
		}

		if (scoreText == null) {
			scoreText = GameObject.Find("Player1Score").GetComponent<Text>();
		}
		if (healthBar == null) {
			healthBar = GameObject.Find("Player1HP").GetComponent<Slider>();
		}   
		if (ammoText == null) {
			ammoText = GameObject.Find("Player1Ammo").GetComponent<Text>();
		}

	}

	public void HideFlagImage1() {
		if (flag1) {
			flag1.enabled = false;
		}
	}

	public void ShowFlagImage1() {
	if (flag1) {
		flag1.enabled = true;
	}
}



public void UpdateScoreText1() {
	if (scoreText) {
		string hud = "Score: " + playerScore;

		scoreText.text = hud;
	}
}

public void UpdateHealthBar1() {
	if (healthBar) {
		healthBar.value = playerHP;
	}
}


public void UpdateAmmoText1() {
	if (ammoText) {
		string hud = "Ammo: " + playerAmmo;

		ammoText.text = hud;
	}
}

#endregion

	*/
}
