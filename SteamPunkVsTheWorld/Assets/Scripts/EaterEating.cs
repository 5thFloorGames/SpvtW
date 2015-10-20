using UnityEngine;
using System.Collections;

public class EaterEating : MonoBehaviour {

	public bool digesting = false;
	private Animator animator;
	private GameLogic logic;

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy") && !digesting){
			print ("called");
			digesting = true;
			StartCoroutine(timeToBite(other.gameObject));
			Invoke("Digested", 4);
		}
	}

	void Start () {
		animator = transform.parent.gameObject.GetComponentInChildren<Animator>();
		logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
	}

	void Update () {

	}

	void Digested(){
		StartCoroutine(timeToSwallow());
	}

	IEnumerator timeToBite(GameObject other) {
		animator.SetTrigger("Bite");
		yield return new WaitForSeconds(1.417f);
		logic.unregisterEnemy(other);
		Destroy(other);
	}

	IEnumerator timeToSwallow() {
		animator.SetTrigger("Swallow");
		yield return new WaitForSeconds(1);
		digesting = false;
	}

}
