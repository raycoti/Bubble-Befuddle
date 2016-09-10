using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	// Use this for initialization

	void Start () {
	}

	
	// Update is called once per frame
	void Update () {

				
	}

	private void OnEnable()
	{
		// tap to break ball
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}
	
	private void OnDisable()
	{
		// remove all registered callback function
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void tappedHandler(object sender, EventArgs e)
	{
		SceneManager.LoadScene("multiplayer");
		
	}




}
