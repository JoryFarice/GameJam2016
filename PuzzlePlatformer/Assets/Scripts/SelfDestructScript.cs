using UnityEngine;
using System.Collections;

public class SelfDestructScript : MonoBehaviour
{
	void Update()
	{
		Destroy(this.gameObject,5f);
	}
}

