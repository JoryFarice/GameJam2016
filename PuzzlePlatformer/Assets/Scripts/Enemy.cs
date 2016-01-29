using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public Player2 player2;

	public int enemyHP;

	// Use this for initialization
	void Start ()
	{
		player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(enemyHP <= 0)
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == ("PlayerBullet"))
		{
			Destroy(coll.gameObject);
			player2.bulletCount--;
			enemyHP--;
		}
	}
}

