using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour
{
	private GameController gc;
	private GameObject player;
	private GameObject thisObject;
	public bool isTouching = false;
	public float moveSpeed = 3f;
	public bool horiFalseVertTrue;
	private float timer;
	public float moveTime = 3f;


	// Use this for initialization
	void Start ()
	{
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		player = GameObject.FindGameObjectWithTag("Player");
		thisObject = this.gameObject;
		timer = moveTime;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isTouching && gc.whichPlayer == 1)
		//Debug.Log("balls");
			player.transform.parent = thisObject.transform;
		
		else
			player.transform.parent = null;



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
		{
			Debug.Log("balls");
			//isTouching = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == ("StepCheck"))
			{
				isTouching = false;
				//Debug.Log("balls");
			}
	}
}

