using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject eyes;

	private bool attacking = false;
	private float lastAttackTime = 0f;
	private float attackInterval = 1.5f;

	[SerializeField]
	private GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player") == null)
			return;

		if (attacking) {
			Vector3 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
			Vector3 eyeDirection = (playerPos - eyes.transform.position).normalized;
			eyes.transform.position = transform.position + new Vector3(eyeDirection.x * 0.5f, eyeDirection.y * 0.5f, eyeDirection.z);
		}

		if (((Time.realtimeSinceStartup - lastAttackTime) >= attackInterval) && attacking) {
			GameObject bulletInstance = Instantiate (bullet) as GameObject;
			bulletInstance.transform.position = transform.position;
			bulletInstance.GetComponent<EnemyBullet>().Target = GameObject.FindGameObjectWithTag ("Player");
			Destroy (bulletInstance, 3f);
			lastAttackTime = Time.realtimeSinceStartup;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player> ();

		if (player != null) {
			BeginAttacking();
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player> ();
		
		if (player != null) {
			StopAttacking();
		}
	}

	private void BeginAttacking() {
		attacking = true;

	}

	private void StopAttacking() {
		attacking = false;
		eyes.transform.position = transform.position;
	}
}
