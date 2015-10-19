using UnityEngine;
using System.Collections;

public class ResourceObjectLogic : MonoBehaviour {

    public bool globalResource = false;
    private SpriteRenderer sprite;

    private bool available = true;
    private bool spawning = true;
    private bool absorbtionStarted = false;
    private float realSize;
    private float lifeTime;
    private float spawnTime;

    private Vector3 landingPos;
    private Vector3 spawningPos;

    private float clickTime;
    private float lifetimeAfterAbsorbed = 4.0f;
    private Vector3 start;
    private Vector3 finish;



    // Use this for initialization
    void Start () {
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        finish = new Vector3(-1.65f, 0.95f, 0);
        realSize = transform.localScale.y;
        float startyPos = transform.position.y;
        float startxPos = transform.position.x;
        spawnTime = Time.time;
        lifeTime = 11.0f;
		transform.localScale = new Vector3(0, 0, 1);
		transform.position = new Vector3(startxPos, (startyPos+0.36f), -1);
		spawningPos = transform.position;
		landingPos = new Vector3 (Random.Range((startxPos-0.50f),(startxPos+0.50f)),
		                        Random.Range ((startyPos-0.50f),(startyPos)), -1);

        if (globalResource) {
            landingPos = new Vector3(Random.Range(0.0f, 8.0f),
                                Random.Range(-4.0f, 0.0f), -1.0f);
            lifeTime = 15f;
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
        selfDestructionCheck();
	}

	void OnMouseDown(){
        if (available) {
            emit(20);
            available = false;
            clickTime = Time.time;
            iTween.Stop(gameObject);
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
        float delay;
        string easeType;
        string oncomplete = "emit10";
        Vector3 movement = landingPos - spawningPos;
        if (globalResource) {
            timeToGoToPosition = 10.0f;
            delay = 0.0f;
            easeType = "easeInOutCubic";
            oncomplete = "emit10";
        } else {
            timeToGoToPosition = 1.0f;
            easeType = "easeInSine";
            delay = timeToGoToPosition;
        }
        if (!globalResource) {
            iTween.MoveBy(gameObject, iTween.Hash("y", 1.0f, "time", timeToGoToPosition / 2, "easeType", iTween.EaseType.easeOutQuad));
            movement.y = movement.y - 1.0f;
        }
        iTween.MoveBy(gameObject, iTween.Hash("amount", movement, "time", timeToGoToPosition / 2, "delay", delay / 2, "easeType", easeType, "oncomplete", oncomplete));
	}

    void emit(int amount) {
        gameObject.GetComponent<ParticleSystem>().Emit(amount);
    }

    void emit10() {
        emit(10);
    }

    void goToTheGenerator() {
        transform.position = Vector3.Lerp(start, finish, (Time.time - clickTime));
        if (Vector3.Distance(transform.position, finish) < 0.01f) {
            ResourceManager.addResources(1);
            absorbtionStarted = true;
        }
    }

    void getAbsorbed() {
        if (Vector3.Distance(transform.position, finish) > 0.01f) {
            transform.position = finish;
        }
        getSmaller();
        lifetimeAfterAbsorbed -= Time.deltaTime;
        if (lifetimeAfterAbsorbed < 0) {
            Destroy(gameObject);
        }
    }

    void getSmaller() {
        float size = transform.localScale.y;
        if (size < 0) {
            size = 0;
        }
        transform.localScale = new Vector3((size - Time.deltaTime), (size - Time.deltaTime), 1);
    }

    void selfDestructionCheck() {
        if (Time.time - spawnTime > lifeTime) {
            fadeAndSuicide();
        }
    }

    void fadeAndSuicide() {
        iTween.ColorTo(sprite.gameObject, iTween.Hash("a", 0.0f, "time", 3.0f, "oncomplete", "suicide",  "oncompletetarget", gameObject));
    }

    void suicide() {
        Destroy(gameObject);
    }
}
