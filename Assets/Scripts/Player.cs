using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IInputObserver {
	public int maxJumps = 1;
	public float jumpPower = 200f;
	public float moveSpeed = 10f;

	[SerializeField]
	private InputManager inputManager;

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private GameObject eyes;

	private Rigidbody2D rigidbody;
	private int jumpsRemaining;
	private Vector3 moveDirection = Vector3.zero;
	private float bulletSpeedX = 1200f;
	private float bulletSpeedY = 0f;
	
	void Start () {
		inputManager.AddObserver (this);
		this.rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		jumpsRemaining = maxJumps;
	}

	void Update () {
		this.rigidbody.velocity = new Vector2 (moveDirection.x * Time.deltaTime, this.rigidbody.velocity.y);

		if (moveDirection.x < 0f) {
			eyes.transform.position = new Vector3 (transform.position.x + (-0.05f * transform.localScale.x), 
			                                       transform.position.y, 
			                                       eyes.transform.position.z);
		} else if (moveDirection.x > 0f) {
			eyes.transform.position = new Vector3 (transform.position.x + (0.05f * transform.localScale.x), 
			                                       transform.position.y, 
			                                       eyes.transform.position.z);
		} else {
			eyes.transform.position = new Vector3 (transform.position.x, 
			                                       transform.position.y, 
			                                       eyes.transform.position.z);
		}

		this.rigidbody.gravityScale = 1 + (((transform.localScale.x + transform.localScale.y) / 2) * 0.05f);
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

		case InputButton.Shoot:
			Shoot();
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

		if ((transform.localScale.x + transform.localScale.y) < 2f) {
			Debug.Log ("GAME OVER");
			inputManager.enabled = false;
			moveDirection = Vector3.zero;
		}
	}

	void Shoot() {
		GameObject bullet = Instantiate(this.bullet);
		bullet.transform.position = transform.position;

		if (moveDirection.x < 0) {
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-bulletSpeedX, bulletSpeedY));
		} else if (moveDirection.x > 0) {
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bulletSpeedX, bulletSpeedY));
		} else {
			GameObject bullet2 = Instantiate(this.bullet);
			bullet2.transform.position = transform.position;

			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-bulletSpeedX, bulletSpeedY));
			bullet2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bulletSpeedX, bulletSpeedY));
			Destroy (bullet2, 3);
			Grow (-2);
		}

		Destroy (bullet, 3);
		Grow (-2);
	}
}
