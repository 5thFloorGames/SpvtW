using UnityEngine;
using System.Collections;

public class PlantDamageScript : MonoBehaviour {

	public int health = 4;
	public Plant plantType;
	private Animator animator;
	private bool broken = false;
	
	void Start () {
		if (plantType == Plant.Blocker) {
			animator = gameObject.GetComponentInChildren<Animator>();
		}
	}
	
	public void Damaged(){
		health--;
		if (health<40 && !broken && plantType == Plant.Blocker) {
			animator.runtimeAnimatorController = Resources.Load("AnanasBreaking") as RuntimeAnimatorController;
			broken = true;
		}
		if (health == 0) {
			if(tag.Equals("Shooter")){
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().unregisterShooter(gameObject);
			}
			transform.parent.SendMessage("Free");
			Destroy(gameObject);
		}
	}	
}
