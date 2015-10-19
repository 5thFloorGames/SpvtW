using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatMove : MonoBehaviour {
	
	private Rigidbody2D rigid;
	private Animator animator;
	private PlantDamageScript eating; 

	void Awake() {
		animator = gameObject.GetComponentInChildren<Animator>();
	}
	
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.tag.Equals ("Plant") || other.gameObject.tag.Equals ("Shooter"))
		    && other.gameObject.transform.position.x < gameObject.transform.position.x) {
			eating = other.gameObject.GetComponent<PlantDamageScript>();
			Stop ();
		}
	}

	public void Stop(){
		rigid.velocity = Vector2.zero;
		animator.runtimeAnimatorController = Resources.Load("CatEating") as RuntimeAnimatorController;
		InvokeRepeating ("Eat", 1f, 0.5f);
	}

	public void Eat(){
		if (eating != null) {
			eating.Damaged();
		} else {
			CancelInvoke();
			Go ();
		}
	}
	
	public void Go(){
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
		animator.runtimeAnimatorController = Resources.Load("CatWalking") as RuntimeAnimatorController;
	}
}