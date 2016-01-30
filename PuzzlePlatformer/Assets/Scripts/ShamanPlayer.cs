/* This is the player one script. It is for the character that can double jump.
*/



using UnityEngine;
using System.Collections;

public class ShamanPlayer : MonoBehaviour {
	public GameController gameController;

	public GameObject CamTar;

	public int bulletCount;

	public float moveSpeed;
	public float jumpHeight;
	private float moveVelocity;

	#region grounded variables
	//transform is a point in space
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded = true;
	public GameObject mcBullet;
	public Transform playerShootPosition;
	public bool dancing = true;
	public float timer;
	private int danceFail;
	public float random;
	private int arrow;
	private bool rolled;
	public bool pressed;
	private int ddrInput;

	public float test;

	private int doubleJumped;
	//private int doubleJumped2;
	#endregion

	//public Transform playerShootPosition;

	//public GameObject mcBullet;

	private Animator anim;


	//usually where you want to do physics stuff in unity
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position , groundCheckRadius , whatIsGround);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

		//test = Input.GetAxisRaw("DDRHori");
	}

	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;

		if(gameController.whichPlayer == 1)
		{
			CamTar.SetActive (true);

			if(dancing == true)
			PlayerControls();
		}
		else
			CamTar.SetActive (false);

		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		anim.SetBool("Grounded", grounded);

		anim.SetInteger("Double", doubleJumped);

		Dance();

		controls();
	}

	#region player collisions

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.transform.tag == "movingPlat")
		{
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.transform.tag == "movingPlat")
		{
			transform.parent = null;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if((other.gameObject.tag == ("Enemy") || other.gameObject.tag == ("Hazzard")) && gameObject.tag == ("Player"))
		{
			gameController.playerRespawn();
		}
	}

	#endregion

	#region player move and shoot and teleport

	public void jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , jumpHeight);
	}

	public void shoot()
	{
		Instantiate(mcBullet, playerShootPosition.position, playerShootPosition.rotation);
		bulletCount++;
	}


	#endregion

	#region player controls

	public void PlayerControls()
	{
		if(grounded && gameObject.tag == ("Player"))
		{
			doubleJumped = 1;
		}

		if(grounded && gameObject.tag == ("Player") && !Input.GetButton("Run"))
		{
			moveSpeed = 7;
		}

		//the next two lines of code are the ones that control the players movement left and right
		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

		if(Input.GetButtonDown("Jump") && grounded && gameObject.tag == ("Player"))
		{
			//to make the character jump
			//Vector2 holds an x and a y value
			jump();
		}

		if(Input.GetButtonDown("Jump") && doubleJumped > 0 && !grounded && gameObject.tag == ("Player"))
		{
			jump();
			doubleJumped -= 1;
		}

		if(Input.GetButton("Run")  && grounded == true)
		{
			moveSpeed = 10;
		}


		if(Input.GetButtonDown("Shoot")  &&  bulletCount < 3)
		{
			shoot();
		}



		//anim.SetFloat("Falling", GetComponent<Rigidbody2D>().velocity.y);

		if(GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		else if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(1f, 1f, 1f);
	}

	#endregion

	public void Dance()
	{
		if(danceFail == 3)
			Debug.Log("You lose");

		if(timer >= 4)//these next two lines will set rolled to false so the thing can roll again
			rolled = false;

		if(timer >= 4.2f && pressed == false && rolled == false) //if you fail to press the button
		{
			dancing = false;//turn player controls off
			danceFail += 1;//reset the counter to reset to checkpoint if you get to three it respawns
			random = Random.Range(0 , 3);//set the random range from 0-4
			timer = 0;//sets timer to 0
			Debug.Log("Arrow: " + random);
		}
		else
			if(timer >= 4.2f && pressed == true && rolled == false ) //if you press the correct button
			{
				dancing = true;//keep player controls on
				danceFail = 0;//reset the counter to reset to checkpoint if you get to three it respawns
				random = Random.Range(0 , 4);//set the random range from 0-4
				timer = 0;//sets timer to 0
				Debug.Log("Arrow: " + random);
			}

		//this will reset pressed making the player have to press the next button
		if(timer == 0)
			pressed = false;
			rolled = true;// makes it so you don't keep rolling a number

		#region set arrows
		//these next few will make it so the random chooses an arrow int that will be chosen
		/*if(random == 1)
			arrow = 0;//arrow 0 = left

		if(random == 2)
			arrow = 1;//arrow 1 = right


		if(random == 3)
			arrow = 2;//arrow 2 = down

		if(random == 4)
			arrow = 3;//arrow 3 = up*/
		#endregion

		if(random == 0 && ddrInput == 0 && pressed == false)
		{
			pressed = true;
			dancing = true;
			Debug.Log("Pressed left: 0");
		}


		if(random == 1 && ddrInput == 1 && pressed == false)
		{
			pressed = true;
			dancing = true;
			Debug.Log("Pressed right: 1");
		}



		if(random == 2 && ddrInput == 2 && pressed == false)
		{
			pressed = true;
			dancing = true;
			Debug.Log("Pressed down: 2");
		}


		if(random == 3 && ddrInput == 3 && pressed == false)
		{
			pressed = true;
			dancing = true;
			Debug.Log("Pressed up: 3");
		}


							
	}

	public void controls()
	{
		if(Input.GetAxisRaw("DDRHori") < -.5)
			ddrInput = 0;
		else

		if(Input.GetAxisRaw("DDRHori") > .5)
			ddrInput = 1;
		else

		if(Input.GetAxisRaw("DDRVert") < -.5)
			ddrInput = 2;
		else

		if(Input.GetAxisRaw("DDRVert") > .5)
			ddrInput = 3;
					else
						ddrInput = -1;


	}
}

