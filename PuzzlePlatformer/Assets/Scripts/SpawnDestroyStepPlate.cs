/* This script is used for stepping on objects with the characters to either spawn or destroy something for the puzzle
 * Everything is public so you can check the appropriate box to make sure that the action you want to take place does
 * If you want multiple characters to have to tand on buttons you can make multiple verticle edge colliders on the same object
 * In order to make it so that things can be animated just make it so the objects have animators on them that run when they spawn but don't loop
 * Make sure that the layer that the objects that this script is on is "SpawnDestroy"
*/

using UnityEngine;
using System.Collections;

public class SpawnDestroyStepPlate : MonoBehaviour {

	public bool spawnTrueFalseDestroy;
	public int howManyCharactersNeeded;
	public int howManyCharactersAreOnThePoint;
	public GameObject whatToSpawnOrDestroy;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spawnTrueFalseDestroy == true && howManyCharactersNeeded == howManyCharactersAreOnThePoint)
			Spawn();
		else
			if(spawnTrueFalseDestroy == false && howManyCharactersNeeded == howManyCharactersAreOnThePoint)
				Destroy();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == ("StepCheck"))
		howManyCharactersAreOnThePoint++;
	}

	void OnTriggerExit2D(Collider2D other)
	{
	if(other.tag == ("StepCheck"))
		{
			Debug.Log("working");
			howManyCharactersAreOnThePoint--;
		}
	}

	public void Spawn()
	{
		whatToSpawnOrDestroy.SetActive (true);
	}

	public void Destroy()
	{
		whatToSpawnOrDestroy.SetActive (false);
	}


}


