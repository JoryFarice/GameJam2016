using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == ("PlayerBullet"))
		{
			Destroy(this.gameObject);
			Destroy(other.gameObject);
		}
	}
}

