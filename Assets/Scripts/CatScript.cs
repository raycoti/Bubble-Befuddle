using UnityEngine;
using System.Collections;
using System; 
using UnityEngine.UI;
public class CatScript : MonoBehaviour {
	public GameObject Cat;

	// Use this for initialization
	void Start () {
		Cat = GameObject.Find ("Cat"); 
	}
	
	// Update is called once per frame
	void Update () {
		Cat.transform.Rotate (0, 0, 80 * Time.deltaTime); 

	}
}
