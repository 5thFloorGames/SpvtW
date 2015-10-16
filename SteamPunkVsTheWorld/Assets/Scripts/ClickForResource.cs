using UnityEngine;
using System.Collections;

public class ClickForResource : MonoBehaviour {

	public float journeyTime = 0.1F;

	private bool growing;
    private bool clickable;
	private bool returningToPosition;
	private bool resourceRegistered;
	private bool goingUp;
    private Vector3 start;
    private Vector3 finish;
    private float startTime;
	private float returnstartTime;
    private bool selfDestructing = false;
    private float timeToDie = 4.0f;
	private float startSize;
	private float startyPos;
	private float startxPos;
	private Vector3 landingPos;
	private Vector3 spawningPos;



	// Use this for initialization
	void Start () {
        clickable = true;
		growing = true;
		returningToPosition = false;
        finish = new Vector3(-1.65f, 0.95f, 0);
		startSize = transform.localScale.y;
		startyPos = transform.position.y;
		startxPos = transform.position.x;
		transform.localScale = new Vector3(0, 0, 1);
		transform.position = new Vector3(startxPos, (startyPos+0.36f), -1);
		spawningPos = transform.position;
		landingPos = new Vector3 (Random.Range((startxPos-0.50f),(startxPos+0.50f)),
		                        Random.Range ((startyPos-0.50f),(startyPos+0.50f)), -1);
	}
	
	// Update is called once per frame
	void Update () {
		grow();
		spawningAnimation ();
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
				ResourceScript.addResources(1);
                selfDestructing = true;
            }
        }
	}

	void OnMouseDown(){
        if (clickable) {
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
				returningToPosition = true;
				returnstartTime = Time.time;
			}
		}
	}

	void spawningAnimation() {
		if (goingUp) {

		} else if (returningToPosition) {
			Vector3 center = (spawningPos + landingPos) * 0.5f;
			if (landingPos.x < spawningPos.x) {
				center += new Vector3(0, 1, 0);
			} else {
				center -= new Vector3(0, 1, 0);
			}
			Vector3 upRelCenter = spawningPos - center;
			Vector3 downRelCenter = landingPos - center;
			float complete = (Time.time - returnstartTime) / journeyTime;
			transform.position = Vector3.Slerp(upRelCenter, downRelCenter, complete);
			transform.position += center;
			if (Vector3.Distance(transform.position, landingPos) < 0.01f) {
				returningToPosition = false;
				transform.position = landingPos;
				gameObject.GetComponent<ParticleSystem>().Emit(20);
			}
		}
	}
}
