using UnityEngine;
using System.Collections;

public class PartyHatLife : MonoBehaviour {

    private SpriteRenderer sprite;
    private GameObject spriteObject;
    private Vector3 landingPos;
    private Vector3 spawningPos;
    private float lifeTime;
    private float spawnTime;

    // Use this for initialization
    void Start () {
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        spriteObject = sprite.gameObject;
        spawnTime = Time.time;
        lifeTime = 6.0f;

        spriteObject.transform.position += (new Vector3(0.19f, 1.34f, 0));
        spriteObject.transform.Rotate(new Vector3(0, 0, 12.0f));
        float rotateAmount = Random.Range(0.69f, 0.99f);
        Vector3 movement = new Vector3(
            Random.Range(-0.00f, 1.23f),
            Random.Range(-2.21f, -1.21f),
            0);

        rotateAmount *= 1;
        if (Random.Range(0, 2) == 0) {
            rotateAmount *= -1;
        }
        iTween.MoveBy(gameObject, iTween.Hash("y", 0.5f, "delay", 0.2f, "easeType", iTween.EaseType.easeOutQuad));
        iTween.RotateBy(spriteObject, iTween.Hash("z", rotateAmount, "delay", 0.3f, "time", 1.4f, "easeType", "easeInSine"));
        iTween.MoveBy(gameObject, iTween.Hash("amount", movement, "delay", 0.7f, "time", 1.0f, "easeType", "easeInSine"));

        //iTween.MoveBy(gameObject, iTween.Hash("y", 1.0f, "time", timeToGoToPosition, "easeType", iTween.EaseType.easeOutQuad));
        //iTween.MoveBy(gameObject, iTween.Hash("amount", movement, "time", timeToGoToPosition, "delay", timeToGoToPosition, "easeType", "easeInSine"));
    }
	
	// Update is called once per frame
	void Update () {
        selfDestructionCheck();
    }

    void selfDestructionCheck() {
        if (Time.time - spawnTime > lifeTime) {
            fadeAndSuicide();
        }
    }

    void fadeAndSuicide() {
        iTween.ColorTo(sprite.gameObject, iTween.Hash("a", 0.0f, "time", 3.0f, "oncomplete", "suicide", "oncompletetarget", gameObject));
    }

    void suicide() {
        Destroy(gameObject);
    }
}
