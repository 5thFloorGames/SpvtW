using UnityEngine;
using System.Collections;

public class MenuLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        checkMusic();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Application.LoadLevel(1);
        }
    }

    void checkMusic() {
        GameObject musicObject = GameObject.Find("MusicControls");
        if (musicObject == null) {
            musicObject = Instantiate<GameObject>((GameObject)Resources.Load("MusicControls"));
            musicObject.name = "MusicControls";
        }
    }

    public void loadScene(int level) {
        Application.LoadLevel(level);
    }

    public void exitGame() {
        Application.Quit();
    }
}
