using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using TouchScript;
using TouchScript.Gestures;
using TouchScript.Hit;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BubbleGenerator : MonoBehaviour {
	public Text waterlevel;
	public Text score;
	public Text Timeleft;
	//private float leveltime ;
	// Use this for initialization
	public Transform ball;
	public Transform bfish;
	public Transform spongeBubble;
	public bool sponge = false;
	private float timer = 0f;
	public float liters = 0;
	public int popped = 0;
	public bool gamewin = false;
	public bool gameover = false;
	public bool gamelost = false;
	public bool fish = false;
	public float time;
	public int r;
	//public GameObject gs; 
	private GameObject water1;
	private GameObject water2;
	private BubbleGenerator2 gsscript2; //access player 2 scores
	//private GameObject cat;
	private GameObject fishswim1;
	private GameObject fishswim2;

	public AudioClip backgroundMusic;
	// Update is called once per frame
	void Start () {

		water1 = GameObject.Find ("waterlevel");

		fishswim2 = GameObject.Find ("swim2");
		fishswim1 = GameObject.Find ("swim1");
		gsscript2 = this.GetComponent<BubbleGenerator2> ();
		r = Random.Range (10, 30);
		//cat = GameObject.Find ("Cat");


		if(backgroundMusic)
			AudioSource.PlayClipAtPoint(backgroundMusic, transform.position);
	}
	



	void Awake(){
		timer = Time.time + 1;
		//leveltime = Time.time + 30;
	}

	void Update(){
		time = Time.timeSinceLevelLoad;
		Vector3 temp1 = new Vector3 (-Mathf.Sin (Time.time) / 40, Mathf.Sin (Time.time * 5) / 75, 0.0f);
		water1.transform.position += temp1;

		Vector3 ftemp1 = new Vector3 (0.0023f, Mathf.Sin (Time.time * 10) / 75, 0.0f);
		fishswim1.transform.position += ftemp1;
		Vector3 ftemp2 = new Vector3 (0.005f, Mathf.Sin (Time.time * 5) / 50, 0.0f);
		fishswim2.transform.position += ftemp2;

			if (gameover == false) {
				waterlevel.text = liters.ToString ();
				Timeleft.text = Math.Round(time,1).ToString(); 
			if (popped > 4 && fish == false){
				fish = true;
				var x2 = Random.Range (-7,7);
				var y2 = Random.Range (2,4);
				var obj2 = Instantiate (bfish) as Transform;
				obj2.transform.position = new Vector3(x2,y2,0);

			}
			if (liters > 38) {
				gamelost = true;

					gameover = true;
					SceneManager.LoadScene("multiplayer");
				}
	
			if(time > 120.0f){
				gameover = true;
			}
				if (timer < Time.time) {
					Makebubble ();
					if (timer > 60.0f){
						Makebubble ();
					
					}
					timer = Time.time + 1;
				}
			}
			//int r = Random.Range (10, 20);
			if (time > r && sponge == false) {
						sponge = true;
						var x3 = Random.Range (-7, 7);
						var y3 = Random.Range (0, 6);
						var obj3 = Instantiate (spongeBubble) as Transform;
						obj3.transform.position = new Vector3 (x3, y3, 0);
				} 


			if (gameover == true) {
			Timeleft.text = "GAME OVER";
					if(liters< gsscript2.liters){
					//waterlevel.text = "GAME";
					//score.text = "OVER";
					//Timeleft.text = "GAME OVER";
					SceneManager.LoadScene("multiplayer");//loads this scene when you lose
			        }
			        else{
				        SceneManager.LoadScene("multiplayer");
			        }
			
					
			}
			if (Input.GetKeyDown("up")) {
				SceneManager.LoadScene ("multiplayer");//restarts when up arrow is pressed
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