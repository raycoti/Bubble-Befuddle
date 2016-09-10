using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;

public class BallGenerator : MonoBehaviour {

	public Transform ball;
	public Transform container;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnEnable()
	{
		if (TouchManager.Instance != null)
		{
			TouchManager.Instance.TouchesBegan += touchBeganHandler;
		}
	}
	
	private void OnDisable()
	{
		if (TouchManager.Instance != null)
		{
			TouchManager.Instance.TouchesBegan -= touchBeganHandler;
		}
	}
	
	private void touchBeganHandler(object sender, TouchEventArgs e)
	{
		foreach (var point in e.Touches)
		{

			Vector3 wp = Camera.main.ScreenToWorldPoint(point.Position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);
			if (GetComponent<Collider2D>() != Physics2D.OverlapPoint(touchPos))
			{
				// don't generate ball then
				//Debug.Log("Hit something");
				return;
			}

			// random color
			Color color = new Color(Random.value, Random.value, Random.value);

			var obj = Instantiate(ball) as Transform;
			obj.parent = container;
			obj.name = "Ball";
			obj.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(point.Position.x, point.Position.y, 10));


			obj.GetComponent<Renderer>().material.color = color;
			obj.GetComponent<Rigidbody2D>().AddForce(0.02f * Random.insideUnitCircle);
		}
	}

}
