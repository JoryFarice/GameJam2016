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
	private RawImage arrow1, arrow2, arrow3, arrow4;
	private bool danceActive = false;
	private ShamanPlayer player;
	private float alpha0;
	private float alpha255;

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
		danceActive = player.dancing;

	}

	// Update is called once per frame
	void Update ()
	{
		danceActive = player.dancing; //Check if the player is currently dancing.

		//This segment will turn the arrows on and off in accordance to what arrow the game expects the player to press. 
		if(Input.GetKeyDown(KeyCode.J)) //Will change this to if the player is currently dancing. 
		{
			arrow1.enabled = true;
			arrow2.enabled = true;
			arrow3.enabled = true;
			arrow4.enabled = true;
		}

		if(Input.GetKeyDown(KeyCode.H)) //Testing enabling and disabling the arrows.
		{
			arrow1.enabled = false;
			arrow2.enabled = false;
			arrow3.enabled = false;
			arrow4.enabled = false;
		}
		
		waitTime -= Time.deltaTime;
		if(waitTime <= 0)
		{
		timer -= 1;
		waitTime = 1;
		}

		timerText.text = ("Time: " + timer);

	}

	public void playerRespawn ()
	{
		GameObject.FindGameObjectWithTag ("Player").transform.position = GameObject.FindGameObjectWithTag ("Spawn").transform.position;
	}

}
