using UnityEngine;
using System.Collections;

public class ClickForResource : MonoBehaviour {

	private bool growing;
    private bool clickable;
    private Vector3 start;
    private Vector3 finish;
    private float startTime;
    private bool selfDestructing = false;
    private float timeToDie = 4.0f;
	private float startSize;


	// Use this for initialization
	void Start () {
        clickable = true;
        finish = new Vector3(-1.65f, 0.95f, 0);
		startSize = transform.localScale.y;
		growing = true;
		transform.localScale = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		grow();
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

	void grow() {
		if (growing) {
			float size = transform.localScale.y;
			if (size < startSize) {
				transform.localScale = new Vector3 ((size+Time.deltaTime), (size+Time.deltaTime), 1);
			} else {
				growing = false;
			}
		}
	}
}
