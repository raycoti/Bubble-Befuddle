using UnityEngine;
using System.Collections;

public class spongetime : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
		timer = Time.time + 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < Time.time) {
			Destroy (this.gameObject);
		}
	}
}
