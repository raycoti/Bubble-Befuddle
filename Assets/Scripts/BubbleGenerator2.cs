using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BubbleGenerator2 : MonoBehaviour {
	public Text waterlevel;
	public Text score;
	public Text Timeleft;
	//private float leveltime ;
	// Use this for initialization
	public Transform ball;
	public Transform pfish;
	private float timer;
	public float liters = 0;
	public int popped = 0;
	public bool gamewin = false;
	public bool gameover = false;
	public bool gamelost = false;
	public bool fish = false;
	private BubbleGenerator gsscript;
	private GameObject gs; 
	public float time;

	
	private GameObject fishswim3;
	private GameObject fishswim4;
	private GameObject water1p2;
	private GameObject water2p2;

	public AudioClip backgroundMusic;
	// Update is called once per frame
	// Use this for initialization
	void Start () {
		//gs = GameObject.Find ("Background");
		//gsscript = gs.GetComponent<BubbleGenerator> ();
		water1p2 = GameObject.Find ("waterlevel2p");

		fishswim3 = GameObject.Find ("swim3");
		fishswim4 = GameObject.Find ("swim4");
	}
	
	// Update is called once per frame
	void Awake(){
		timer = Time.time + 1;
		//leveltime = Time.time + 30;
	}
	
	void Update(){
		time = Time.timeSinceLevelLoad;
		Vector3 temp1 = new Vector3 (Mathf.Sin (Time.time) / 40, Mathf.Sin (Time.time * 5) / 75, 0.0f);
		water1p2.transform.position += temp1;

		Vector3 ftemp3 = new Vector3 (-0.003f, Mathf.Sin (Time.time * 5) / 25, 0.0f);
		fishswim3.transform.position += ftemp3;
		Vector3 ftemp4 = new Vector3 (-0.001f, Mathf.Sin (Time.time * 5) / 75, 0.0f);
		fishswim4.transform.position += ftemp4;

		if (gameover == false) {
			waterlevel.text =  liters.ToString ();
			//score.text = "SCORE: " + popped.ToString ();
			//Timeleft.text = "Time: " + Math.Round((Time.time),2).ToString(); 
			if (popped > 4 && fish == false){
				fish = true;
				var x2 = Random.Range (-7,7);
				var y2 = Random.Range (2,4);
				var obj2 = Instantiate (pfish) as Transform;
				obj2.transform.position = new Vector3(x2,y2,0);
			}
			if (liters > 38) {
				gamelost = true;
				
				gameover = true;

				SceneManager.LoadScene("multiplayer");
			}


			/*if(time > 60.0f){
				gameover = true;
			}*/

			if (timer < Time.time) {
				Makebubble ();
				if (timer > 60.0f){
					Makebubble ();

				}
				timer = Time.time + 1;
			}
		}

	}
	
	
	void Makebubble(){
		var x2 = Random.Range (-7, 7);
		var y2 = Random.Range (0, 4);
		var obj2 = Instantiate (ball) as Transform;
		obj2.transform.position = new Vector3 (x2, y2, 0);
		obj2.GetComponent<Rigidbody2D>().AddForce (0.09f * Random.insideUnitCircle);
		
	}
}
	
