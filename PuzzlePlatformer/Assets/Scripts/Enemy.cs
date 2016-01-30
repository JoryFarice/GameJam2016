using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public ShamanPlayer player;

	public int enemyHP;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<ShamanPlayer>();
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

