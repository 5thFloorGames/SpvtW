using UnityEngine;
using System.Collections;

public class CatMove : MonoBehaviour {
	
	private Rigidbody2D rigid;
	private Animator animator;
	private RuntimeAnimatorController control;
	
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
		animator = gameObject.GetComponentInChildren<Animator>();
		animator.runtimeAnimatorController = Resources.Load("CatWalking") as RuntimeAnimatorController;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void Stop(){
		rigid.velocity = Vector2.zero;
		animator.runtimeAnimatorController = Resources.Load("CatEating") as RuntimeAnimatorController;
	}
	
	public void Go(){
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
		animator.runtimeAnimatorController = Resources.Load("CatWalking") as RuntimeAnimatorController;

	}
}