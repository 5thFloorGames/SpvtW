using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatMove : MonoBehaviour {

	public int maxHealth;
	public bool hasHat;
	
	private Rigidbody2D rigid;
	private Animator animator;
	private GameObject eating;
	private int currentHealth;

	void Awake() {
		animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Start () {
		currentHealth = maxHealth;
		rigid = gameObject.GetComponent<Rigidbody2D>();
		rigid.MovePosition(transform.position + (Vector3.left / 500f));
	}

	void Update () {
	}

	void Damaged(){
		currentHealth--;

		if ((currentHealth <= maxHealth/2) && hasHat) {
			if (eating != null) {
				animator.runtimeAnimatorController = Resources.Load("CatEating") as RuntimeAnimatorController;
			} else {
				animator.runtimeAnimatorController = Resources.Load("CatWalking") as RuntimeAnimatorController;
			}
			gameObject.GetComponentInChildren<Transform>().Translate(new Vector3(-0.11f,-0.16f,0));
			hasHat = false;
		}

		if (currentHealth == 0) {
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().unregisterEnemy(gameObject);
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.tag.Equals ("Plant") || other.gameObject.tag.Equals ("Shooter"))
		    && other.gameObject.transform.position.x < gameObject.transform.position.x) {
			eating = other.gameObject;
			Stop ();
		}
	}

	public void Stop(){
		rigid.velocity = Vector2.zero;
		if (hasHat) {
			animator.runtimeAnimatorController = Resources.Load ("PartyCatEating") as RuntimeAnimatorController;
		} else {
			animator.runtimeAnimatorController = Resources.Load ("CatEating") as RuntimeAnimatorController;
		}
		InvokeRepeating ("Eat", 1f, 0.5f);
	}

	public void Eat(){
		if (eating != null) {
			eating.SendMessage("Damaged");
		} else {
			CancelInvoke();
			Go ();
		}
	}
	
	public void Go(){
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));

		if (hasHat) {
			animator.runtimeAnimatorController = Resources.Load("PartyCatWalking") as RuntimeAnimatorController;
		} else {
			animator.runtimeAnimatorController = Resources.Load("CatWalking") as RuntimeAnimatorController;
		}
	}
}