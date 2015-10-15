using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	private List<GameObject> plants;
	public List<Button> buttons;
	private List<GameObject> previews;
	public Plant active;

	// Use this for initialization
	void Start () {
		plants = new List<GameObject>();
        plants.Add(null);
        plants.Add ((GameObject)Resources.Load("Producer"));
		plants.Add ((GameObject)Resources.Load("Shooter"));
		plants.Add ((GameObject)Resources.Load("Blocker"));
		Vector3 previewLocation = new Vector3 (-4f, -4f, 0f);
		previews = new List<GameObject> ();
		previews.Add (null);
		previews.Add ((GameObject)Instantiate(Resources.Load("ProducerPreview"),previewLocation, Quaternion.identity));
		previews.Add ((GameObject)Instantiate(Resources.Load("ShooterPreview"),previewLocation, Quaternion.identity));
		previews.Add ((GameObject)Instantiate(Resources.Load("BlockerPreview"),previewLocation, Quaternion.identity));
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(1)) {
            if (active != Plant.None) {
                getPreview().transform.position = new Vector3(-4f, -4f, 0f);
                ChangePlant("None");
            }
        }
    }

	public void ChangePlant (string plantName){
		active = (Plant) System.Enum.Parse( typeof( Plant ), plantName );
	}

	public void ChangePlant (Plant plant){
		active = plant;
	}

	public GameObject buildPlant(){
		if (active != Plant.None) {
			ResourceScript.buyPlant (active);
			buttons[(int)active].SendMessage("ActivateCooldown");
			return plants[(int)active];
		} else {
			return null;
		}
	}

	public GameObject getPreview(){
		return previews[(int)active];
	}
}
