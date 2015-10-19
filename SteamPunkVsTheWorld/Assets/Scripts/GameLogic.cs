using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour {

	private List<GameObject> plants;
	public List<Button> buttons;
	private List<GameObject> previews;
	public Plant active;
	private List<GameObject> shooters = new List<GameObject>();
	private List<GameObject> enemies = new List<GameObject>();
	private SpawnDirector director;
	public LevelEnd youWon;

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
		director = gameObject.GetComponent<SpawnDirector> ();
		ResourceManager.reset ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.LoadLevel(0);
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
            ResourceManager.buyPlant (active);
			buttons[(int)active].SendMessage("ActivateCooldown");
			return plants[(int)active];
		} else {
			return null;
		}
	}

	public GameObject getPreview(){
		return previews[(int)active];
	}

	public void registerShooter(GameObject shooter){
		shooters.Add (shooter);
		updateShooters ();
	}

	public void registerEnemy(GameObject enemy){
		enemies.Add (enemy);
		updateShooters ();
	}

	public void unregisterShooter(GameObject shooter){
		shooters.Remove (shooter);
		updateShooters();
	}

	public void unregisterEnemy(GameObject enemy){
		enemies.Remove (enemy);
		updateShooters();
		if (enemies.Count == 0 && director.noMoreEnemies()) {
			youWon.Enable();
		}
	}
	
 	public void updateShooters(){
		foreach(GameObject shooter in shooters){
			if(shooter != null){
				if(EnemyInSameLane(shooter)){
					shooter.SendMessage("StartShooting");
				} else {
					shooter.SendMessage("Stop");
				}
			}
		}
	}

	public bool EnemyInSameLane(GameObject shooter){
		foreach(GameObject enemy in enemies){
			if(enemy != null){
				if(shooter.transform.position.y == enemy.transform.position.y 
				   && shooter.transform.position.x < enemy.transform.position.x){
					return true;
				}
			}
		}
		return false;
	}
}
