using UnityEngine;
using System.Collections;

public class CatMove : MonoBehaviour {

	private bool moving = true;
	private Rigidbody2D rigid;
	
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			gameObject.GetComponent<Rigidbody2D>().MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
		}
	}

	public void Stop(){
		moving = false;
	}
	
	public void Go(){
		moving = true;
	}
}
