using UnityEngine;
using System.Collections;

public class BreakingPlatform : MonoBehaviour
{
	
	private float BreakTimer = 6f;
	private bool hasBeenStepped = false;
	//private float RebuildTimer;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if(RebuildTimer < 5f)
			RebuildTimer += Time.deltaTime;*/

		if(BreakTimer < 6f)
			BreakTimer += Time.deltaTime;

		if((BreakTimer <= .5f) || (BreakTimer >= 5f))
		{
			this.GetComponent<BoxCollider2D>().enabled = (true);
			this.GetComponent<MeshRenderer>().enabled = (true);
		}
		else
		{
			this.GetComponent<BoxCollider2D>().enabled = (false);
			this.GetComponent<MeshRenderer>().enabled = (false);
		}
		
		/*if(RebuildTimer >= 4f)
		this.GetComponent<BoxCollider2D>().enabled = (true);
		*/
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == ("StepCheck")  && hasBeenStepped == false)
		{
			if(hasBeenStepped == false)
				BreakTimer = 0f;
			hasBeenStepped = true;
			Debug.Log("fuck me right?");
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == ("StepCheck") && hasBeenStepped == true)
		{
			hasBeenStepped = false;
			Debug.Log("fuck me right?");
		//	BreakTimer = 0f;
		}
	}
}

