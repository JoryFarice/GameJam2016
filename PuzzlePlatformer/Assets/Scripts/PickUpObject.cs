/*
 * 
*/


using UnityEngine;
using System.Collections;

public class PickUpObject : MonoBehaviour {


	public bool isHoldingSomething = false;
	private bool isTouching = false;
	private GameObject thisObject;
	private GameObject player;
	public ShamanPlayer sPlayer;
	public float fallSpeed = 1f;
	private bool grounded = true;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		thisObject = this.gameObject;
		player = GameObject.FindGameObjectWithTag("CarryPoint");
	}


	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position , groundCheckRadius , whatIsGround);

		if(grounded == false && isHoldingSomething == false)
		{
			transform.Translate(-Vector2.up * fallSpeed * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonUp("PickUp"))
		{
			thisObject.transform.parent = null;
			isHoldingSomething = false;
			this.GetComponent<BoxCollider2D>().size = new Vector2 (1f , 1f);
			sPlayer.anim.SetBool("PickingUp", false);
		}

		if (isHoldingSomething == false && Input.GetButton("PickUp") && isTouching == true)
		{
			thisObject.transform.parent = player.transform;
			isHoldingSomething = true;
			this.GetComponent<BoxCollider2D>().size = new Vector2 (.9f , 1f);
			sPlayer.anim.SetBool("PickingUp", true);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "CarryPoint")
		{
			isTouching = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "CarryPoint")
		{
			isTouching = false;
		}
	}

	/*void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player3")
		{
			isTouching = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player3")
		{
			isTouching = false;
		}
	}*/

	public void BecomeChild(Transform newParent)
	{
		
	}
}
