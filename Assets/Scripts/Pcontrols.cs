using UnityEngine;
using System.Collections;

public class Pcontrols : MonoBehaviour {
	public float playerSpeed = 1f;
	public float playerJump = 1f;
	public float playerTurn = 1f;
	public float grav = 1f;
	private Vector3 playerDirection = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			playerDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
			playerDirection = transform.TransformDirection(playerDirection);
			playerDirection *= playerSpeed;
			if (Input.GetKeyDown(KeyCode.Space))
				playerDirection.y = playerJump;
			
		}
		playerDirection.y -= grav * Time.deltaTime;
		controller.Move(playerDirection * Time.deltaTime);
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0f,-5f * playerTurn,0f);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0f,5f * playerTurn,0f);
		}

	}
	}

