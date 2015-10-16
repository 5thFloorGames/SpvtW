using UnityEngine;
using System.Collections;

public class ClickForResource : MonoBehaviour {

    public bool globalResource = false;

    private bool available = true;
    private bool spawning = true;
    private bool absorbtionStarted = false;
    private float realSize;

    private Vector3 landingPos;
    private Vector3 spawningPos;

    private float clickTime;
    private float lifetimeAfterAbsorbed = 4.0f;
    private Vector3 start;
    private Vector3 finish;



    // Use this for initialization
    void Start () {
        finish = new Vector3(-1.65f, 0.95f, 0);
        realSize = transform.localScale.y;
        float startyPos = transform.position.y;
        float startxPos = transform.position.x;
        
		transform.localScale = new Vector3(0, 0, 1);
		transform.position = new Vector3(startxPos, (startyPos+0.36f), -1);
		spawningPos = transform.position;
		landingPos = new Vector3 (Random.Range((startxPos-0.50f),(startxPos+0.50f)),
		                        Random.Range ((startyPos-0.50f),(startyPos)), -1);

        if (globalResource) {
            landingPos = new Vector3(Random.Range(0.0f, 8.0f),
                                Random.Range(-4.0f, 0.0f), -1.0f);
        }

	}
	
	// Update is called once per frame
	void Update () {
		spawn();
        if (absorbtionStarted) {
            getAbsorbed();
        } else if (!available) {
            goToTheGenerator();
        } else {
            // be at normal state
        }
        
	}

	void OnMouseDown(){
        if (available) {
            emit(20);
            available = false;
            clickTime = Time.time;
            start = transform.position;
			if (gameObject.GetComponent<MovementScript>() != null) {
				gameObject.GetComponent<MovementScript>().enabled = false;
			}
        }
	}

	void spawn() {
		if (spawning) {
			float size = transform.localScale.y;
			if (size < realSize) {
				transform.localScale = new Vector3 ((size+Time.deltaTime), (size+Time.deltaTime), 1);
			} else {
				spawning = false;
                spawningAnimation();
            }
		}
	}

	void spawningAnimation() {
        emit(10);
        float timeToGoToPosition;
        string eztype;
        if (globalResource) {
            timeToGoToPosition = 10.0f;
            eztype = "easeInOutCubic";
        } else {
            timeToGoToPosition = 1.0f;
            eztype = "easeInSine";
        }
        iTween.MoveBy(gameObject, iTween.Hash("y", 1.0f, "time", timeToGoToPosition / 2, "easeType", iTween.EaseType.easeOutQuad));
        Vector3 movement = landingPos - spawningPos;
        movement.y = movement.y - 1.0f;
        iTween.MoveBy(gameObject, iTween.Hash("amount", movement, "time", timeToGoToPosition / 2, "delay", timeToGoToPosition / 2, "easeType", eztype));
	}

    void emit(int amount) {
        gameObject.GetComponent<ParticleSystem>().Emit(amount);
    }

    void goToTheGenerator() {
        transform.position = Vector3.Lerp(start, finish, (Time.time - clickTime));
        if (Vector3.Distance(transform.position, finish) < 0.01f) {
            ResourceScript.addResources(1);
            absorbtionStarted = true;
        }
    }

    void getAbsorbed() {
        float size = transform.localScale.y;
        if (size < 0) {
            size = 0;
        }
        lifetimeAfterAbsorbed -= Time.deltaTime;
        transform.localScale = new Vector3((size - Time.deltaTime), (size - Time.deltaTime), 1);
        if (lifetimeAfterAbsorbed < 0) {
            Destroy(gameObject);
        }
    }
}
