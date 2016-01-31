/* This is a game controller script it holds most of the variables on the game
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public int whichPlayer;
	public int timer;
	public float waitTime = 1f;

	private Text timerText;
	private RawImage arrow1, arrow2, arrow3, arrow4, needs, pressssssed, wrong;
	//private bool danceActive = false;
	private ShamanPlayer player;
	private float random;

	private GameController control;



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
		//playerRespawn();
		timerText = GameObject.Find("Timer").GetComponent<Text>();
		arrow1 = GameObject.Find("ArrowUp").GetComponent<RawImage>();
		arrow2 = GameObject.Find("ArrowRight").GetComponent<RawImage>();
		arrow3 = GameObject.Find("ArrowLeft").GetComponent<RawImage>();
		arrow4 = GameObject.Find("ArrowDown").GetComponent<RawImage>();
		player = GameObject.Find("Shaman").GetComponent<ShamanPlayer>();
		needs = GameObject.Find("NeedsPress").GetComponent<RawImage>();
		wrong = GameObject.Find("Wrong").GetComponent<RawImage>();
		pressssssed = GameObject.Find("Pressed").GetComponent<RawImage>();

	}

	// Update is called once per frame
	void Update ()
	{
		arrowAppearence();
		
		waitTime -= Time.deltaTime;
		if(waitTime <= 0)
		{
		timer -= 1;
		waitTime = 1;
		}

		timerText.text = ("Time: " + timer);

	/*	if(timer <= 0)
		{
			playerRespawn();
			timer = 180;
		}*/
	}

	public void playerRespawn ()
	{
		GameObject.FindGameObjectWithTag ("Player").transform.position = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
		//Debug.Log("i should respawn");
	}

	public void arrowAppearence()
	{
		//This segment will turn the arrows on and off in accordance to what arrow the game expects the player to press. 
		if(player.random == 0 && player.pressed == false) //If the "left" arrow is the one the player wants...
		{
			arrow1.enabled = false;
			arrow2.enabled = false;
			arrow3.enabled = true;
			arrow4.enabled = false;
		}
		if(player.random == 1 && player.pressed == false) //If the "right" arrow is the one the player wants... 
		{
			arrow1.enabled = false;
			arrow2.enabled = true;
			arrow3.enabled = false;
			arrow4.enabled = false;
		}
		if(player.random == 2 && player.pressed == false) //If the "down" arrow is the one the player wants...
		{
			arrow1.enabled = false;
			arrow2.enabled = false;
			arrow3.enabled = false;
			arrow4.enabled = true;
		}
		if(player.random == 3 && player.pressed == false) //If the "up" arrow is the one the player wants...
		{
			arrow1.enabled = true;
			arrow2.enabled = false;
			arrow3.enabled = false;
			arrow4.enabled = false;
		}

		if(player.pressed == true)
		{
			arrow1.enabled = false;
			arrow2.enabled = false;
			arrow3.enabled = false;
			arrow4.enabled = false;
			pressssssed.enabled = true;
			needs.enabled = false;
		}

		else
		{
			needs.enabled = true;
			pressssssed.enabled = false;
		}

		if (player.dancing == false)
			wrong.enabled = true;
		else
			wrong.enabled = false;
	}
}
