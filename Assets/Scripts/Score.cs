using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static float score = 0;

	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}
}
