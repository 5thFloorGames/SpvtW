using UnityEngine;
using System.Collections;

public class EaterEating : MonoBehaviour {

	public bool digesting = false;
	private Animator animator;
	private GameLogic logic;
	private AudioSource bitesfx;

	void Start () {
		bitesfx = gameObject.GetComponent<AudioSource>();
		animator = transform.parent.gameObject.GetComponentInChildren<Animator>();
		logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>();
	}

	void Update () {

	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy") && !digesting){
			print ("called");
			digesting = true;
			StartCoroutine(timeToBite(other.gameObject));
			Invoke("Digested", 40);
		}
	}

	void Digested(){
		StartCoroutine(timeToSwallow());
	}

	IEnumerator timeToBite(GameObject other) {
		animator.SetTrigger("Bite");
		bitesfx.PlayDelayed (1f);
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
