/* This script is to be put on the players bullets. It decideds which direction the players bullets should go in.
*/

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float moveSpeed;
	public ShamanPlayer shamanScript;
	public  GameObject player;
	private float timer;

	// Use this for initialization
	void Start ()
	{
		

		shamanScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ShamanPlayer>();

		player = GameObject.FindGameObjectWithTag("Player");

		if(player.transform.localScale.x < 0 )
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
			shamanScript.bulletCount--;
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log("balllllls");
	//	shamanScript.bulletCount--;
	}
}
