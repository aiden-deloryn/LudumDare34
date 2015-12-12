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
		this.rigidbody.velocity = new Vector2 (moveDirection.x * Time.deltaTime, this.rigidbody.velocity.y);
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

	public void Grow(float amount) {
		transform.localScale += new Vector3 (amount / 4, amount / 4, 0f);

		if ((transform.localScale.x + transform.localScale.y) < 1f) {
			Debug.Log ("GAME OVER");
		}
	}
}
