using UnityEngine;
using System.Collections;

public class TimerPlus : ItemPickUp
{
	private GameController control;
	
	void Start()
	{
		control = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			if(control.timer >= 471)
			{
				control.timer = 500;
			}
			else{
			control.timer += 30;
			}
		}		
	}
}

