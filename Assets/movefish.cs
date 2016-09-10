
using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
using Random = UnityEngine.Random;
public class movefish : MonoBehaviour {
	private Vector2 startPos = new Vector2();
	public float speed=1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void OnEnable()
	{
		// press/release gesture for adding force like slingshot
		GetComponent<PressGesture>().Pressed += pressedHandler;
		GetComponent<ReleaseGesture>().Released += releasedHandler;
		
		//
	}
	
	private void OnDisable()
	{
		// remove all registered callback function
		GetComponent<PressGesture>().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture>().Released -= releasedHandler;

	}
	
	private void pressedHandler(object sender, EventArgs e)
	{
		// record press point
		var gesture = sender as PressGesture;
		startPos = gesture.NormalizedScreenPosition;
	}
	private void releasedHandler(object sender, EventArgs e)
	{
		// add force!
		var gesture = sender as ReleaseGesture;
		Vector2 force = gesture.NormalizedScreenPosition - startPos;
		GetComponent<Rigidbody2D>().AddForce (force*speed);
	}
}
