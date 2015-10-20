using UnityEngine;
using System.Collections;

public class EaterEating : MonoBehaviour {

	public bool digesting = false;
	private Animator animator;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy") && !digesting){
			digesting = true;
			StartCoroutine(timeToBite(other.gameObject));
			Invoke("Digested", 40);
		}
	}

	// Use this for initialization
	void Start () {
		animator = transform.parent.gameObject.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Digested(){
		animator.SetBool("Eating", false);
		digesting = false;
	}

	IEnumerator timeToBite(GameObject other) {
		animator.SetTrigger("Bite");
		animator.SetBool("Eating", true);
		yield return new WaitForSeconds(1);
		Destroy(other);
	}

}
