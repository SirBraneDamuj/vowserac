using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

  public Vector3 velocity = Vector3.zero;
  
  //walking
  public float acceleration = 1.0f;
  public float maxSpeed = 1.0f;
  public float friction = 0.10f;
  [HideInInspector]
  public float moveDirection = 1;
  public bool paralyzed = false;
  public float paralyzeTimer = 0.0f;
  
  //falling
  public float gravity = 1.0f;
  public float terminalVelocity = 1.0f;
  private CharacterController2D controller;
  
  //jumping
  public float jumpSpeed = 2.0f;

	// Use this for initialization
	void Start () {
    controller = GetComponent<CharacterController2D>();
	}
	
	// Update is called once per frame
	void Update () {
    if(!paralyzed) {
      doMovement();
    } else {
      paralyzeTimer -= Time.deltaTime;
      if(paralyzeTimer <= 0.0f) {
        paralyzed = false;
        paralyzeTimer = 0.0f;
      }
    }
    if(controller.isGrounded) {
      doJump();
    } else {
      doGravity();
    }
    controller.move(velocity * Time.deltaTime);
    if(controller.collisionState.becameGroundedThisFrame) {
      controller.velocity.y = 0;
      velocity.y = 0;
    }
	}
  
  private void doMovement() {
    float input = Input.GetAxisRaw("Horizontal");
    if(input > 0) {
      moveDirection = 1;
      if(transform.localScale.x < 0) {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
      }
    }
    else if(input < 0) {
      moveDirection = -1;
      if(transform.localScale.x > 0) {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
      }
    }
    velocity.x += acceleration * input * Time.deltaTime;
    if(input == 0) {
      velocity.x *= friction;
    }
    velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
    if(Mathf.Abs(velocity.x) <= 0.1f) { velocity.x = 0; }
  }
  
  private void doJump() {
    if(Input.GetButtonDown("Jump")) {
      velocity.y = jumpSpeed;
    }
  }
  
  private void doGravity() {
    if(controller.collisionState.above) {
      velocity.y = Mathf.Min(0, velocity.y);
    }
    velocity.y += -gravity * Time.deltaTime;
    velocity.y = Mathf.Max(velocity.y, -terminalVelocity);
  }
  
  public void AddVelocity(Vector3 delta) {
    velocity.x = -moveDirection * delta.x;
    velocity.y = delta.y;
  }
  
  public void Paralyze(float pTime) {
    paralyzed = true;
    paralyzeTimer = pTime;
  }
  
}
