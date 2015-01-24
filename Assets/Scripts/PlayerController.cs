using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	
	// Player Handling
	public float gravity = 45;
	public float speed = 12;
	public float acceleration = 30;
	public float jumpHeight = 18;
	public float cutJumpSpeed = 10;

	private float animationSpeed;
	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	private bool isJumping;
	private float cutJumpSpeedLimit;
	private bool isPlatformer = false;

	
	private PlayerPhysics playerPhysics;
	//private Animator animator;
	

	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		cutJumpSpeedLimit = gravity / cutJumpSpeed;
		//animator = GetComponent<Animator>();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Run")) {
			if (isPlatformer) {
				isPlatformer = false;
			} 
			else {
				isPlatformer = true;
			}
		}
		 //Reset acceleration upon collision
		if(!isPlatformer)
		{	
			if (playerPhysics.movementStopped) {
				targetSpeed = 0;
				currentSpeed = 0;
			}
		}
		
		// If player is touching the ground
		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			isJumping = false;
			
			// Jump
			if (Input.GetButtonDown("Jump")) {
				amountToMove.y = jumpHeight;
				isJumping = true;
			}

		}
		if (Input.GetButtonUp("Jump") && isJumping && amountToMove.y > cutJumpSpeedLimit) 
		{
			Debug.Log("Entered");
			amountToMove.y = cutJumpSpeedLimit;
		}
		
		// Set animator parameters
		//animationSpeed = IncrementTowards(animationSpeed,Mathf.Abs(targetSpeed),acceleration);
		//animator.SetFloat("Speed",animationSpeed);
		
		// Input
		if (isPlatformer) {
			currentSpeed = speed;
		} 
		else {
			targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
			currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);
		}

		// Set amount to move
		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
		
		// Face Direction
		float moveDir = Input.GetAxisRaw("Horizontal");
		if (moveDir !=0) {
			transform.eulerAngles = (moveDir>0)?Vector3.up * 180:Vector3.zero;
		}

	}
	
	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
		if (n == target) {
			return n;	
		}
		else {
			float dir = Mathf.Sign(target - n); // must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign(target-n))? n: target; // if n has now passed target then return target, otherwise return n
		}
	}
}
