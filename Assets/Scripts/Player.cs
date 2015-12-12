using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour, IInputObserver {
	public float jumpPower = 200f;
	public int maxJumps = 1;

	[SerializeField]
	private InputManager inputManager;

	private Rigidbody2D rigidbody;
	private int jumpsRemaining;

	// Use this for initialization
	void Start () {
		inputManager.AddObserver (this);
		this.rigidbody = gameObject.GetComponent<Rigidbody2D> ();
		jumpsRemaining = maxJumps;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPressed(InputButton button) {
		switch (button) {
		case InputButton.Left:

			break;
		case InputButton.Jump:
			if (jumpsRemaining-- > 0) this.rigidbody.AddForce(new Vector2(0f, jumpPower));
			break;
		}
	}

	public void ButtonReleased(InputButton button) {

	}

	void OnCollisionEnter2D(Collision2D collision) {
		jumpsRemaining = maxJumps;
	}
}
