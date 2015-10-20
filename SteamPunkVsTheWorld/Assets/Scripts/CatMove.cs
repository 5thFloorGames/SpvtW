using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CatMove : MonoBehaviour {

    public int maxHealth;
    public bool hasHat;

    private Rigidbody2D rigid;
    private Animator animator;
    private GameObject eating;
    private int currentHealth;
    private GameObject sprite;
    private bool dying;
    private AudioSource[] audios;
    private AudioSource eatSound;

    void Awake() {
        animator = gameObject.GetComponentInChildren<Animator>();
        audios = gameObject.GetComponents<AudioSource>();
        dying = false;
    }

    void Start() {
        sprite = (GameObject)transform.FindChild("Sprite").gameObject;
        if (hasHat) {
            animator.SetBool("HasHat", true);
            sprite.transform.Translate(new Vector3(0.11f, 0.16f, 0));
        }
        currentHealth = maxHealth;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.MovePosition(transform.position + (Vector3.left / 500f));
    }

    void Update() {
        fadeAndSuicideIfDying();
    }

    void Damaged() {
        currentHealth--;
        //StartCoroutine(flashWhenTakingDamage());

        if ((currentHealth <= maxHealth / 2) && hasHat) {
            sprite.transform.Translate(new Vector3(-0.11f, -0.16f, 0));
            GameObject hat = (GameObject)Instantiate(Resources.Load("PartyHat"));
            hat.transform.position = gameObject.transform.position;
            hat.GetComponentInChildren<SpriteRenderer>().sortingOrder = sprite.GetComponent<SpriteRenderer>().sortingOrder;
            hasHat = false;
            animator.SetBool("HasHat", false);
        }

        if (currentHealth == 0) {
            animator.SetTrigger("Dying");
            rigid.velocity = Vector2.zero;
            //Destroy(GetComponent<Rigidbody2D>());
            //Destroy(gameObject.GetComponent<BoxCollider2D>());
            if (eating) {
                CancelInvoke();
            }
            if (Random.Range(0, 2) == 0) {
                audios[1].PlayDelayed(1.0f);
            } else {
                audios[2].PlayDelayed(1.0f);
            }

            if (eatSound != null) {
                eatSound.Stop();
                eatSound = null;
            }

            dying = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag.Equals("Plant") || other.gameObject.tag.Equals("Shooter"))
            && other.gameObject.transform.position.x < gameObject.transform.position.x) {
            eating = other.gameObject;
            StopMovingStartEating();
        }
    }

    void fadeAndSuicideIfDying() {
        if (dying) {
            iTween.ColorTo(sprite.gameObject, iTween.Hash(
                "a", 0.0f,
                "delay", 4.0f,
                "time", 2.0f,
                "oncomplete", "suicide",
                "oncompletetarget", gameObject));
        }
    }

    void suicide() {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().unregisterEnemy(gameObject);
        Destroy(gameObject);
    }

    public void StopMovingStartEating() {
        rigid.velocity = Vector2.zero;
        animator.SetBool("Eating", true);
        InvokeRepeating("Eat", 1f, 0.5f);
    }

    public void Eat() {
        if (eating != null) {
            eating.SendMessage("Damaged");
            if (eatSound == null) {
                eatSound = audios[0];
                eatSound.Play();
            }
        } else {
            CancelInvoke();
            Go();
        }
    }

    public void Go() {
        rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
        animator.SetBool("Eating", false);
        eatSound.Stop();
        eatSound = null;
    }

    IEnumerator flashWhenTakingDamage() {
        sprite.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.8f);
        yield return new WaitForSeconds(0.1f);
        sprite.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
    }

}