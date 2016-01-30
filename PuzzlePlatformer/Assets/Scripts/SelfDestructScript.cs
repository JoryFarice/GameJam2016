using UnityEngine;
using System.Collections;

public class SelfDestructScript : MonoBehaviour
{
	void Start()
	{
		Destroy(this.gameObject,5f);
	}
}

