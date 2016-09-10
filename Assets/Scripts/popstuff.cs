using UnityEngine;
using System.Collections;

public class popstuff : MonoBehaviour {

	float timer;
	float frame2;
	float lframe;
	float frame3;
	bool f2 =true;
	bool f3 = true;
	bool lf = true;
	public bool good;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite goodjob;
	public Sprite badjob;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		timer = Time.time + 4.0f;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = sprite1;
		print (good);// tomorrow have an image for positive feedback and one for negative feedback. 
		frame2 = Time.time + 0.2f;
		frame3 = Time.time + 0.4f;
		lframe = Time.time + 0.6f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < Time.time) {
			Destroy (this.gameObject);
		}
		else if (frame2 < Time.time && f2 == true) {
			spriteRenderer.sprite = sprite2;
			f2= false;
			
		}
		else if (frame3 < Time.time && f3 ==true ) {
			spriteRenderer.sprite = sprite3;
			f3=false;
			
		}
		else if (lframe < Time.time && lf == true) {
			if (good == true){
				spriteRenderer.sprite = goodjob;
			}
			else{
				spriteRenderer.sprite = badjob;
			}
			
			lf= false;
		}
	}
	
}
