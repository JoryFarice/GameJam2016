/* This script is to be put on the players bullets. It decideds which direction the players bullets should go in.
*/

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float moveSpeed;
	public ShamanPlayer shammy;
	public  GameObject player;
	private float timer;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		shammy = player.GetComponent<ShamanPlayer>();



		if(player.transform.localScale.x < 0 )
		{
			moveSpeed = -moveSpeed;
			//Debug.Log("Fuck me Right?");
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed , 0);
	}
	// Update is called once per frame
	void Update () {

		shammy = player.GetComponent<ShamanPlayer>();

		timer += Time.deltaTime;

		if(timer >= .75f)
		{
			Debug.Log("fuck me right?");
			shammy.bulletCount--;
			shammy.anim.SetBool("Shooting", false);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log("balllllls");
	//	shamanScript.bulletCount--;
	}
}
