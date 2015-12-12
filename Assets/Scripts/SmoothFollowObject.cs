using UnityEngine;
using System.Collections;

public class SmoothFollowObject : MonoBehaviour {
	public GameObject target;
	public float speed = 1f;
	public Vector2 offset = Vector2.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = new Vector3 (this.target.transform.position.x + offset.x, 
		                                 this.target.transform.position.y + offset.y, 
		                                 this.gameObject.transform.position.z);
		gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, targetPos, this.speed * Time.deltaTime);
	}
}
