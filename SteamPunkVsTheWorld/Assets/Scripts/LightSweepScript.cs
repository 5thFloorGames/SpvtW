using UnityEngine;
using System.Collections;

public class LightSweepScript : MonoBehaviour {

	private Rigidbody2D rigid;
	
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}

	public void Sweep(){
		transform.position = new Vector3 (9f,-10f,-2);
		rigid.MovePosition(transform.position + (Vector3.left/4));
	}

	void Update(){
		if (transform.position.x < -5) {
			rigid.velocity = Vector2.zero;
		}
	}
}
