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
	private RawImage arrow1, arrow2, arrow3;
	private bool danceActive = false;

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
		arrow1 = GameObject.Find("Arrow1").GetComponent<RawImage>();
		arrow2 = GameObject.Find("Arrow2").GetComponent<RawImage>();
		arrow3 = GameObject.Find("Arrow3").GetComponent<RawImage>();

	}

	// Update is called once per frame
	void Update ()
	{
		if(danceActive == true)
		{
			arrow1.
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
