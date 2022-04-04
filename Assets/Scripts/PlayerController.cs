using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

        private float movementX;
        private float movementY;

	private Rigidbody rb;
	private int count;
    
    //public LayerMask groundPlayers;
    //public float jumpForce = 7;
    //public SphereCollider col;
    
    
    /*private CharacterController character;
    //Jump Variables
    private Vector3 velocity;
    private bool grounded;
    private float jumpHeight = 5.0f;
    private bool pressed = false;
    private float gravity = -9.81f;*/

	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();
        //col = GetComponent<SphereCollider>();
        
        /*character = GetComponent<CharacterController>();*/

		// Set the count to zero 
		count = 0;

		SetCountText ();

                // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
                winTextObject.SetActive(false);
	}

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

		rb.AddForce (movement * speed);
        
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //}
        
        /*MovementJump();*/
	}

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}
	}

        void OnMove(InputValue value)
        {
        	Vector2 v = value.Get<Vector2>();

        	movementX = v.x;
        	movementY = v.y;
        }
    
    
    /*void MovementJump(){
        
        groundedPlayer = character.grounded;
        
        // If on ground, stop vertical movement
        if(groundedPlayer){
            velocity = 0.0f;
        }
        
        // If Jump pressed and on ground jump the player
        if(pressed && groundedPlayer) {
            velocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity);
            pressed = false;
        }
        
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }*/
    
    /*void OnJump()
    {
        Debug.Log("Jump pressed");
        
        // Check if no vertical movement
        if (character.velocity.y == 0)
        {
            Debug.Log("Can jump");
            pressed = true;
        } else {
            Debug.Log("Can't jump");
        }
    }*/

        void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12) 
		{
                    // Set the text value of your 'winText'
                    winTextObject.SetActive(true);
		}
	}
}