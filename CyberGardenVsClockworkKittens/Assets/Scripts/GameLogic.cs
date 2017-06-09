using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

	private List<GameObject> plants;
	public List<Button> buttons;
	private List<GameObject> previews;
	public Plant active;
	private List<GameObject> shooters = new List<GameObject>();
	private List<GameObject> enemies = new List<GameObject>();
	private SpawnDirector director;
	public LevelEnd eaterUnlock;
	public LevelEnd doubleShooterUnlock;
	public LevelEnd gameWon;
	private AudioSource clickfx;

	void Start () {
		activateButtons ();
		plants = new List<GameObject>();
        plants.Add(null);
        plants.Add ((GameObject)Resources.Load("Producer"));
		plants.Add ((GameObject)Resources.Load("Shooter"));
		plants.Add ((GameObject)Resources.Load("Blocker"));
		plants.Add ((GameObject)Resources.Load("Eater"));
		plants.Add ((GameObject)Resources.Load("DoubleShooter"));
		Vector3 previewLocation = new Vector3 (-4f, -4f, 0f);
		previews = new List<GameObject> ();
		previews.Add (null);
		previews.Add ((GameObject)Instantiate(Resources.Load("ProducerPreview"),previewLocation, Quaternion.identity));
		previews.Add ((GameObject)Instantiate(Resources.Load("ShooterPreview"),previewLocation, Quaternion.identity));
		previews.Add ((GameObject)Instantiate(Resources.Load("BlockerPreview"),previewLocation, Quaternion.identity));
		previews.Add ((GameObject)Instantiate(Resources.Load("EaterPreview"),previewLocation, Quaternion.identity));
		previews.Add ((GameObject)Instantiate(Resources.Load("DoubleShooterPreview"),previewLocation, Quaternion.identity));
		director = gameObject.GetComponent<SpawnDirector> ();
		ResourceManager.reset ();
		clickfx = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameState.reset();
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetMouseButtonDown(1)) {
            if (active != Plant.None) {
                getPreview().transform.position = new Vector3(-4f, -4f, 0f);
                ChangePlant(Plant.None);
            }
        }
    }

	public void ChangePlant (Plant plant){
		if (plant != Plant.None) {
			clickfx.PlayOneShot(clickfx.clip);
		}
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
			LevelWon();
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

	private void activateButtons(){
		for (int i = 1; i <= 3 + GameState.level; i++) {
			Button b = buttons[i];
			if(b != null){
				b.gameObject.SetActive(true);
			}
		}
	}

	private void LevelWon(){
		GameState.levelUp ();
		TurnOffButtons ();
		if (GameState.gameWon()) {
			gameWon.Enable ();
		} else if (GameState.level == 1) {
			eaterUnlock.Enable ();
		} else if (GameState.level == 2) {
			doubleShooterUnlock.Enable ();
		}
	}

	public void TurnOffButtons(){
		for (int i = 1; i < buttons.Count; i++) {
			Button b = buttons[i];
			if(b != null){
				b.gameObject.SetActive(false);
			}
		}
	}
}
