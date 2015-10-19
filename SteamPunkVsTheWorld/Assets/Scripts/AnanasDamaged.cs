using UnityEngine;
using System.Collections;

public class AnanasDamaged : MonoBehaviour {
	public int health = 80;
	private Animator animator;
	private bool broken = false;

	void Start () {
		animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update () {
		if (health<40 && !broken) {
			animator.runtimeAnimatorController = Resources.Load("AnanasBreaking") as RuntimeAnimatorController;
			broken = true;
		}
	}
	
	public void Damaged(){
		health--;
		if (health == 0) {
			transform.parent.SendMessage("Free");
			Destroy(gameObject);
		}
	}
}
