using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public Shaman player;

	public int enemyHP;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player2").GetComponent<Shaman>();
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
			player.bulletCount--;
			enemyHP--;
		}
	}
}

