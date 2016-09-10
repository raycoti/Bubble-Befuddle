using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using System;
using Random = UnityEngine.Random;

public class ballp2 : MonoBehaviour {
	public AudioClip collisionSound;
	public AudioClip popSound;
	//
	public Transform pointss;
	public popstuff ps;
	//speed of bubble
	public float speed=1.0f;
	private GameObject water;
	//private GameObject water2;
	private GameObject gs;
	//private BubbleGenerator gsscript2;
	private BubbleGenerator2 gsscript;
	// variable to store start position of dragging for slingshot!
	private Vector2 startPos = new Vector2();

	// Use this for initialization
	void Start () {
		gs = GameObject.Find ("Background");
		gsscript = gs.GetComponent<BubbleGenerator2> ();
		//gsscript2 = gs.GetComponent<BubbleGenerator> (); 
		water = GameObject.Find ("WaterObject2");
		//water2 = GameObject.Find ("WaterObject");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D target) {
		
		// safeguard: check if the audio clip is assigned
		if (target.gameObject.tag == "Wall") {
			//print ("Test");
			gsscript.liters = gsscript.liters + 1; //purple gets liter added


			Vector3 temp = new Vector3(0,0.2f,0);
			water.transform.position += temp; // purple water level goes up
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ;
			ps.good = false;
			Destroy (this.gameObject);
			//
			//
			//
		}
		if (target.gameObject.tag == "Ball") {
			this.GetComponent<Rigidbody2D>().AddForce(0.1f * Random.insideUnitCircle);		
		}
	
		if (target.gameObject.tag == "Fish") {
			//gsscript2.lostbubbles = gsscript2.lostbubbles + 1;

			gsscript.liters = gsscript.liters + 0.25f; //purple gets slight penatly with .25 liters added
			Vector3 temp = new Vector3 (0, -0.2f, 0);
			water.transform.position += temp;//purple water level goes up
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ;
			ps.good = true;
			Destroy (this.gameObject);
		}
		if (target.gameObject.tag == "BlueFish") {
			//gsscript2.liters = gsscript2.liters - 1; //blue recovers bubble

			gsscript.liters = gsscript.liters + 1; //purple water level goes up
			Vector3 temp = new Vector3(0,0.2f,0);
			//Vector3 temp2 = new Vector3(0,-0.2f,0);
			//water2.transform.position += temp2; // blue water goes down
			water.transform.position += temp; //purple water goes up
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ;
			ps.good = false;
			Destroy (this.gameObject);
		}
		if (target.gameObject.tag == "Sponge") {
			gsscript.liters = gsscript.liters - 1; //purple water level goes down
			Vector3 temp = new Vector3 (0, 0.2f, 0);
			//Vector3 temp2 = new Vector3 (0, -0.2f, 0);
			water.transform.position -= temp; //purple goes down
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ;
			ps.good = true;
			Destroy (this.gameObject);
			
		}

		if (collisionSound)
			// simple audio clip playback
			AudioSource.PlayClipAtPoint(collisionSound, transform.position);
		
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

		
			if(popSound)
				AudioSource.PlayClipAtPoint(popSound, transform.position);
			var obj2 = Instantiate (pointss) as Transform;
			obj2.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,0);
			ps = obj2.GetComponent<popstuff>() ;
			ps.good = true;
			Destroy(gameObject);
			gsscript.popped = gsscript.popped +1;

		
	}
}

