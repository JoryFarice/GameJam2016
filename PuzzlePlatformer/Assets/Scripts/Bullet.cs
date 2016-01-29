/* This script is to be put on the players bullets. It decideds which direction the players bullets should go in.
*/

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float moveSpeed;
	public Player2 player2Script;
	public  GameObject player2;
	private float timer;

	// Use this for initialization
	void Start ()
	{
		

		player2Script = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>();

		player2 = GameObject.FindGameObjectWithTag("Player2");

		if(player2.transform.localScale.x < 0 )
		{
			moveSpeed = -moveSpeed;
			//Debug.Log("Fuck me Right?");
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed , 0);
	}
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >= .75f)
		{
			Debug.Log("fuck me right?");
			player2Script.bulletCount--;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log("balllllls");
		player2Script.bulletCount--;
	}
}
