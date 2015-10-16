using UnityEngine;
using System.Collections;

public class ClickForResource : MonoBehaviour {

    private bool clickable;
    private Vector3 start;
    private Vector3 finish;
    private float startTime;
    private bool selfDestructing = false;
    private float timeToDie = 4.0f;


	// Use this for initialization
	void Start () {
        clickable = true;
        finish = new Vector3(-1.65f, 0.95f, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (selfDestructing) {
            float size = transform.localScale.y;
            if (size < 0) {
                size = 0;
            }
            timeToDie -= Time.deltaTime;
            transform.localScale = new Vector3((size-Time.deltaTime), (size-Time.deltaTime), 1);
            if (timeToDie < 0) {
                Destroy(gameObject);
            }
        } else if (!clickable) {
            transform.position = Vector3.Lerp(start, finish, (Time.time - startTime));
            if (Vector3.Distance(transform.position, finish) < 0.01f) {
                selfDestructing = true;
                //Destroy(gameObject);
            }
        }
	}

	void OnMouseDown(){
        if (clickable) {
            ResourceScript.addResources(1);
            gameObject.GetComponent<ParticleSystem>().Emit(20);
            clickable = false;
            startTime = Time.time;
            start = transform.position;
			if (gameObject.GetComponent<MovementScript>() != null) {
				gameObject.GetComponent<MovementScript>().enabled = false;
			}
        }
	}
}
