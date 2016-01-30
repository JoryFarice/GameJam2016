using UnityEngine;
using System.Collections;

public class SelfDestructScript : MonoBehaviour
{
	void Update()
	{
		if(Time.deltaTime >= 5)
		{
		Destroy(this.gameObject,5f);
		}
	}
}

