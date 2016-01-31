using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == ("Bullet"))
		{
			Destroy(this);
		}
	}
}

