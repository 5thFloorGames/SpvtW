using UnityEngine;
using System.Collections;

public class LightSweepScript : MonoBehaviour {

	private Rigidbody2D rb;
	
	void Start () {
        
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	public void Sweep(){
		transform.position = new Vector3 (9f,-10f,-2);
        rb.velocity = new Vector3(-20f, 0, 0);
	}

	void Update(){

        if (Input.GetButtonDown("Jump")) {
            Sweep();
        }

        if (transform.position.x < -5) {
			rb.velocity = Vector2.zero;
		}
	}
}
