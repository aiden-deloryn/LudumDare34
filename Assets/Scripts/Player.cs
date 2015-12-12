using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IInputObserver {
	public int maxJumps = 1;
	public float jumpPower = 200f;
	public float moveSpeed = 10f;

	[SerializeField]
	private InputManager inputManager;

	private Rigidbody2D rigidbody;
	private int jumpsRemaining;
	private Vector3 moveDirection = Vector3.zero;
	
	void Start () {
		inputManager.AddObserver (this);
		this.rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		jumpsRemaining = maxJumps;
	}

	void Update () {
		gameObject.transform.position += new Vector3(moveDirection.x * Time.deltaTime, 
		                                             moveDirection.y * Time.deltaTime, 
		                                             0f);
	}

	public void ButtonPressed(InputButton button) {
		switch (button) {
		case InputButton.Left:
			moveDirection += new Vector3(-moveSpeed, 0f, 0f);
			break;
		case InputButton.Right:
			moveDirection += new Vector3(moveSpeed, 0f, 0f);
			break;
		case InputButton.Jump:
			if (jumpsRemaining-- > 0) this.rigidbody.AddForce(new Vector2(0f, jumpPower));
			break;
		}
	}

	public void ButtonReleased(InputButton button) {
		switch (button) {
		case InputButton.Left:
			moveDirection -= new Vector3(-moveSpeed, 0f, 0f);
			break;
		case InputButton.Right:
			moveDirection -= new Vector3(moveSpeed, 0f, 0f);
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		jumpsRemaining = maxJumps;
	}
}
