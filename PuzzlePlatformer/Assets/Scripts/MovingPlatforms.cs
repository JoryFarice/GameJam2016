using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour
{
	private GameController gc;
	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject thisObject;
	private bool isTouching = false;
	public float moveSpeed = 3f;
	public bool horiFalseVertTrue;
	private float timer;
	public float moveTime = 3f;


	// Use this for initialization
	void Start ()
	{
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		player1 = GameObject.FindGameObjectWithTag("Player1");
		player2 = GameObject.FindGameObjectWithTag("Player2");
		player3 = GameObject.FindGameObjectWithTag("Player3");
		thisObject = this.gameObject;
		timer = moveTime;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isTouching && gc.whichPlayer == 1)
		//Debug.Log("balls");
			player1.transform.parent = thisObject.transform;
		
		else
			player1.transform.parent = null;

		if(isTouching && gc.whichPlayer == 2)
			//Debug.Log("balls");
			player2.transform.parent = thisObject.transform;
		else
			player2.transform.parent = null;
		
		if(isTouching && gc.whichPlayer == 3)
			//Debug.Log("balls");
			player3.transform.parent = thisObject.transform;
		else
			player3.transform.parent = null;

		if(horiFalseVertTrue == false)
		{
			if(timer > 0)
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

			if(timer < 0)
				transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);

			if(timer <= -moveTime)
				timer = moveTime;
		}
		else
			if(horiFalseVertTrue == true)
			{
				if(timer > 0)
					transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

				if(timer < 0)
					transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);

				if(timer <= -moveTime)
					timer = moveTime;
			}

		timer -= Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == ("StepCheck"))
			isTouching = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == ("StepCheck"))
			isTouching = false;
	}
}

