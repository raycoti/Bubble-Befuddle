// Ball script
// 

using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {

	// collision sound clip
	public AudioClip collisionSound;
	public AudioClip popSound;
	public Transform pointss;
	
	//
	private popstuff ps;
	//speed of bubble
	public float speed=1.0f;
	private GameObject water; //waterlevel
   // private GameObject water2;
	private GameObject gs; 
	//private GameObject water2;
	//private BubbleGenerator2 gsscript2; // access player 2 scores
	private BubbleGenerator gsscript; // player 1 scores
	// variable to store start position of dragging for slingshot!
	private Vector2 startPos = new Vector2();
    private float lit;
	// Use this for initialization
	void Start () {
		gs = GameObject.Find ("Background");
		gsscript = gs.GetComponent<BubbleGenerator> ();
        lit = gsscript.liters;
        		//gsscript2 = gs.GetComponent<BubbleGenerator2> ();
		water = GameObject.Find ("WaterObject");
		//water2 = GameObject.Find ("WaterObject2");



	}

	// Update is called once per frame
	void Update () {

	}

	// Collision handling: make a bouncing sound when hit a wall
	void OnCollisionEnter2D(Collision2D target) {

		// safeguard: check if the audio clip is assigned
		if (target.gameObject.tag == "Wall") {
			//print ("Test");
			lit += 1; //blue team gets a liter added
            
			Vector3 temp = new Vector3(0,0.2f,0);
			water.transform.position += temp; //blue water level moves up

			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ;
			ps.good = false;

			Destroy (this.gameObject);

		}
		if (target.gameObject.tag == "BlueFish") {
			lit += 0.25f; //blue team gets slight penalty of .25 liters
			Vector3 temp = new Vector3(0,-0.2f,0);
			water.transform.position += temp; //blue water level goes down
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ; //get the component for this
			ps.good = true;// right now it is good or bad bool, but we can make it into an integer if we want varying score results

			Destroy (this.gameObject);
		}
		if (target.gameObject.tag == "Fish") {
			lit += 1; //blue gets a liter added
			Vector3 temp = new Vector3 (0, 0.2f, 0);
			water.transform.position += temp; //blue goes up

			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ; //get the component for this
			ps.good = false;// right now it is good or bad bool, but we can make it into an integer if we want varying score results

			Destroy (this.gameObject);

		}
		if (target.gameObject.tag == "Sponge") {
			lit -= 1; //blue gets a liter added
			
			//gsscript2.lostbubbles = gsscript2.lostbubbles - 1; //purple recovers a bubble
			Vector3 temp = new Vector3 (0, 0.2f, 0);
			//Vector3 temp2 = new Vector3 (0, -0.2f, 0);
			water.transform.position -= temp; //blue goes down
			//water2.transform.position += temp2; //purple goes down
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ; //get the component for this
			ps.good = true;// right now it is good or bad bool, but we can make it into an integer if we want varying score results

			Destroy (this.gameObject);
			
		}
		if (target.gameObject.tag == "Ball") {
			this.GetComponent<Rigidbody2D>().AddForce(0.1f * Random.insideUnitCircle);		
		}
		

	}

	private void OnEnable()
	{
		// press/release gesture for adding force like slingshot
		GetComponent<PressGesture>().Pressed += pressedHandler;
		GetComponent<ReleaseGesture>().Released += releasedHandler;

		// tap to break ball
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}
	
	private void OnDisable()
	{
		// remove all registered callback function
		GetComponent<PressGesture>().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture>().Released -= releasedHandler;
		GetComponent<TapGesture>().Tapped += tappedHandler;
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

	private void tappedHandler(object sender, EventArgs e)
	{
		gsscript.popped = gsscript.popped + 1;
			if(popSound)
				AudioSource.PlayClipAtPoint(popSound, transform.position);
		var obj2 = Instantiate (pointss) as Transform;
		obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
		ps = obj2.GetComponent<popstuff>() ; //get the component for this
		ps.good = true;// right now it is good or bad bool, but we can make it into an integer if we want varying score results

		Destroy(gameObject);
			


	}
}