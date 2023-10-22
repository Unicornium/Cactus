using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CactusController : MonoBehaviour {
	// how fast the cactus can move
	public float topSpeed = 10f;
	// tell the sprite which direction it is pointing
	bool facingRight = true;

	//get reference to annimator 
	Animator anim;

	//not grounded
	bool grounded = false;
	//transform at cactus foot to see if is touching the ground
	public Transform groundCheck;
	//how big the circle is going to be when we check distance to the ground
	float groundRadius = 0.2f;
	//force of the jump
	public float jumpForce = 700f;
	//What layer is considered ground
	public LayerMask whatIsGround;
	//variable to check double jump
	bool doubleJump = false;
	//using collider for swich
	List<Collider2D> inColliders = new List<Collider2D>();

	//Button move
	private float MoveButton;
	private bool Move;
	private float direction;
	private float MoveVariant;


	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;

	
	[SerializeField]
	private AudioSource StepsSound;
	[SerializeField]
	private AudioSource jumpSound;



	[SerializeField]
	GameObject HomeUI;

	void Start(){
			anim = GetComponent<Animator> ();

		StepsSound = GetComponent<AudioSource> ();
	}

	//physics in fixed update
	void FixedUpdate(){

		//true or false did the transform hit the whatIsGround wihc the groungRadius
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//tell the animator that we are grounded
		anim.SetBool("Ground", grounded);
		//reset double jump
		if (grounded)
			doubleJump = false;
		//get how fast we are moving up or down from the rigidbody
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);

	

		//get move direction
		float move = MoveVariant; // Input.GetAxis ("Horizontal");
		
		// If not knock back - move on.
		if (knockbackCount <= 0) {
			// add velocity to the rigidboby in	the direction * our speed
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * topSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			
			//StepsSound.Pitch = Random.Range(0.9f, 1.1f);
		} else {
			if (knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);
			if (!knockFromRight)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);
			knockbackCount -= Time.deltaTime;
		

		}

		anim.SetFloat ("Speed", Mathf.Abs (move));
		//Steps sound
		//if ((!doubleJump && Input.GetButtonDown("Jump")) && (!Move && grounded))
			


		//if we're face the negative direction and not faceing right, flip
		if (move > 0 && !facingRight)
				flip ();
		else if (move < 0 && facingRight)
				flip ();

		if (Move) {
			
			MoveVariant = MoveButton;

		}
		else {
			MoveVariant = Input.GetAxis ("Horizontal");
		}
		
	}

	void Update(){
		if ((grounded || !doubleJump) && Input.GetKeyDown (KeyCode.Space)){
			//not on the ground
			anim.SetBool ("Ground", false);
			jumpSound.Play();
			//add lump force to the Y axsis of the rigidbody
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));

			if (!doubleJump && !grounded)
				doubleJump = true;
			jumpSound.Play();

			//swich use button jump or fire1

			//if(Input.GetButtonDown("Fire1"))
			if (Input.GetButtonDown("Jump"))
				inColliders.ForEach(n => n.SendMessage("Use",SendMessageOptions.DontRequireReceiver));



		}
	}


	void flip(){
		//saying we are facing the oposite direction
		facingRight = !facingRight;

		//get the local scale
		Vector3 theScale = transform.localScale;

		//flip on x axis
		theScale.x *= -1;
		//apply that to local scale
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D col){

		inColliders.Add (col);

	}

	void OnTriggerExit2D(Collider2D col){

		inColliders.Remove (col);

	}

	
	public void BtnJump(){
		//swich use button jump
		inColliders.ForEach(n => n.SendMessage("Use",SendMessageOptions.DontRequireReceiver));

		if (grounded || !doubleJump) {
			//not on the ground
			anim.SetBool ("Ground", false);
			//add lump force to the Y axsis of the rigidbody
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));

			if (!doubleJump && !grounded)
				doubleJump = true;
		}
	}

	public void BtnHome(){
		
		//stop all movement
		GetComponent<CactusController>().enabled = false;
		//enabels the deathUI
		HomeUI.gameObject.SetActive (true);
		//Pause game on
		Time.timeScale = 0f;
	}
	public void BtnReturn(){

		//on all movement
		GetComponent<CactusController>().enabled = true;
		//desabels the deathUI
		HomeUI.gameObject.SetActive (false);
		//Pause game off
		Time.timeScale = 1f;


	}
	public void TryAgain()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
	}


	public void BtnMove(float direction){

		this.direction = direction;
		this.Move = true;

		//get move direction
		MoveButton = direction;
		
		// add velocity to the rigidboby in	the direction * our speed
		//GetComponent<Rigidbody2D>().velocity = new Vector2(direction * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

		//anim.SetFloat("Speed", Mathf.Abs(direction));

		//if we're face the negative direction and not faceing right, flip
		/*if (direction > 0 && !facingRight)
			flip();
		else if (direction < 0 && facingRight)
			flip();
		*/

	}

	public void BtnStopMove (){

		this.direction = 0;
		Move = false;
	}
	private void FootStep() 
	{
		StepsSound.Play();
	}
}

