using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	private bool attacking = false;
	private float lastAttackTime = 0f;
	private float attackInterval = 2f;

	[SerializeField]
	private GameObject bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (((Time.realtimeSinceStartup - lastAttackTime) >= attackInterval) && attacking) {
			GameObject bulletInstance = Instantiate (bullet) as GameObject;
			bulletInstance.transform.position = transform.position;
			bulletInstance.GetComponent<EnemyBullet>().Target = MultiTags.FindGameObjectWithTag(Tag.Player);
			lastAttackTime = Time.realtimeSinceStartup;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player> ();

		if (player != null) {
			Debug.Log("Saw player");
			attacking = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player> ();
		
		if (player != null) {
			Debug.Log("Lost player");
			attacking = false;
		}
	}

	private void BeginAttacking() {
		attacking = true;
	}

	private void StopAttacking() {
		attacking = false;
	}
}
