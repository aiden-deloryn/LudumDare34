using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	private GameObject target;
	private Vector3 direction = Vector3.zero;
	private float speedModifier = 0.3f;

	float Size {
		get {
			return (this.gameObject.transform.localScale.x + this.gameObject.transform.localScale.y);
		}
	}

	public GameObject Target {
		get {
			return target;
		}

		set {
			target = value;
			direction = (target.transform.position - transform.position).normalized;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.position += new Vector3(direction.x * speedModifier, direction.y * speedModifier, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player> ();

		if (player != null) {
			player.Grow(-Size);
			Destroy(this.gameObject);
		}
	}
}
