using UnityEngine;
using System.Collections;

public class DialogBoxes : MonoBehaviour
{
	public Transform messagePrefab;
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player" && (GameObject.FindGameObjectWithTag("Message")==null))
		{
		Instantiate(messagePrefab, new Vector2(this.transform.position.x, this.transform.position.y + 3),Quaternion.identity);
		}
	}
}

