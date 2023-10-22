using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2 : MonoBehaviour 
{
	
	private Rigidbody2D myRigidbody;

	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private float jumpForce;

	//using collider for swich
	List<Collider2D> inColliders = new List<Collider2D>();

	// Use this for initialization
	void Start () 
	{
		facingRight = true;

		myRigidbody = GetComponent<Rigidbody2D> ();

		myAnimator = GetComponent<Animator> ();		
	}


	// Update is called fixed per frame
	void FixedUpdate () 
	{
		//input 
		float horizontal = Input.GetAxis ("Horizontal");

		//isGrounded = IsGounded ();
		//update method
		HandeleMovement (horizontal);

		Flip (horizontal);
	}

	// Update is called one per frame
	void Update()
	{
		//swich use button jump or fire1

		//if(Input.GetButtonDown("Fire1"))
		if(Input.GetButtonDown("Jump"))
			inColliders.ForEach(n => n.SendMessage("Use",SendMessageOptions.DontRequireReceiver));
	}


	private void HandeleMovement(float horizontal)
	{
		if (isGrounded && jump)
		{
			isGrounded = false;
			myRigidbody.AddForce (new Vector2 (0, jumpForce));
		}
			
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);

		myAnimator.SetFloat ("Speed", Mathf.Abs(horizontal));
	}


	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
	}


	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}


	}


	private bool IsGrounded()
	{
		if(myRigidbody.velocity.y <= 0)
		{
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders [i].gameObject != gameObject) 
					{
						return true;
					}
				}
			}
		}
		return false;
	}


	public void BtnJump()
	{
		//swich use button jump
		inColliders.ForEach(n => n.SendMessage("Use",SendMessageOptions.DontRequireReceiver));


	}


	public void BtnHome()
	{

	}


	public void BtnMove()
	{

	}




}
