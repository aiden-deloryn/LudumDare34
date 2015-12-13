using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour, IInputObserver {
	public int maxJumps = 1;
	public float jumpPower = 200f;
	public float moveSpeed = 10f;
	public AudioClip hitSound;
	public AudioClip jumpSound;

	[SerializeField]
	private InputManager inputManager;

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private GameObject eyes;

	private Rigidbody2D rigidbody;
	private int jumpsRemaining;
	private Vector3 moveDirection = Vector3.zero;
	private float bulletSpeed = 1200f;
	
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

		this.rigidbody.gravityScale = 1 + (((transform.localScale.x + transform.localScale.y) / 2) * 0.02f);
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
			if (jumpsRemaining-- > 0) { 
				this.rigidbody.AddForce(new Vector2(0f, jumpPower));
				GetComponent<AudioSource> ().PlayOneShot (jumpSound);
			}
			break;

		case InputButton.ShootUp:
		case InputButton.ShootDown:
		case InputButton.ShootLeft:
		case InputButton.ShootRight:
			Shoot(button);
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
		if (amount < 0)
			GetComponent<AudioSource> ().PlayOneShot (hitSound);

		if ((transform.localScale.x + transform.localScale.y) < 2f) {
			StartCoroutine(ReloadLevel());
			GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>().enabled = true;
			inputManager.enabled = false;
			moveDirection = Vector3.zero;
		}
	}

	void Shoot(InputButton button) {
		GameObject bullet = Instantiate(this.bullet);
		bullet.transform.position = transform.position;

		switch (button) {
		case InputButton.ShootUp:
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, bulletSpeed));
			break;
		case InputButton.ShootDown:
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, -bulletSpeed));
			break;
		case InputButton.ShootLeft:
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-bulletSpeed, 0f));
			break;
		case InputButton.ShootRight:
			bullet.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bulletSpeed, 0f));
			break;
		}

		Destroy (bullet, 3);
		Grow (-2);
	}

	private IEnumerator ReloadLevel() {
		yield return new WaitForSeconds (5f);
		Application.LoadLevel (Application.loadedLevel);
	}
}
