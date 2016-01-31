using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel2 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		nextLevelWater();
	}

	public void nextLevelWater()
	{
		SceneManager.LoadScene(2);
	}
}

