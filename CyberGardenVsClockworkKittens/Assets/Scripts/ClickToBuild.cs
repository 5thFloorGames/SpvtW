using UnityEngine;
using System.Collections;

public class ClickToBuild : MonoBehaviour {

	public bool free = true;
	private GameLogic logic;
	public int childLayer;
	public AudioSource plantSound;

	// Use this for initialization
	void Start () {
		logic = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

	void OnMouseDown(){
		if (free) {
			GameObject thingTobuild = logic.buildPlant();
			if(thingTobuild != null){
				GameObject newPlant = (GameObject)Instantiate(thingTobuild, transform.position, Quaternion.identity);
				newPlant.transform.parent = transform;
				newPlant.GetComponentInChildren<SpriteRenderer>().sortingOrder = childLayer;
				if(newPlant.tag.Equals("Shooter")){
					logic.registerShooter(newPlant);
				}
				free = false;
				plantSound.PlayOneShot(plantSound.clip);
				GameObject thingToPreview = logic.getPreview ();
				thingToPreview.transform.position = new Vector3(-4f,-4f,0f);
				logic.ChangePlant(Plant.None);
			}
		}

		//this.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		//print ("stuff");

	}

	void OnMouseOver(){
		if (free) {
			GameObject thingToPreview = logic.getPreview ();
			if(thingToPreview != null){
				thingToPreview.transform.position = transform.position;
				thingToPreview.GetComponentInChildren<SpriteRenderer>().sortingOrder = childLayer;
			}
		}
	}

	void OnMouseExit(){
		if (free) {
			GameObject thingToPreview = logic.getPreview ();
			if(thingToPreview != null){
				thingToPreview.transform.position = new Vector3(-4f,-4f,0f);
			}
		}
	}

	void Free(){
		free = true;
	}
}
