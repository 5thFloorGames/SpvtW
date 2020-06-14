using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class CatMove : MonoBehaviour {

    public int maxHealth;
    public bool hasHat;
	public bool isRunner;

    private int currentHealth;
    private Vector3 speed;
    private bool isMoving;
    private bool dying;

    private PlantDamageScript eating;
    private Rigidbody2D rigid;
    private Animator animator;
    private GameObject sprite;
    private AudioSource[] audios;
    private AudioSource eatSound;


    private void Awake() {
        animator = gameObject.GetComponentInChildren<Animator>();
        audios = gameObject.GetComponents<AudioSource>();
    }

    private void Update()
    {
        if (!isMoving) return;
        rigid.MovePosition(transform.position + speed);
    }

    private void Start() {
        sprite = (GameObject)transform.Find("Sprite").gameObject;
        if (hasHat) {
            animator.SetBool("HasHat", true);
            sprite.transform.Translate(new Vector3(0.11f, 0.16f, 0));
        }
        currentHealth = maxHealth;
        rigid = gameObject.GetComponent<Rigidbody2D>();
		if (isRunner) {
			speed = (Vector3.left / 200f);
		} else {
			speed = (Vector3.left / 500f);
		}
        isMoving = true;
        
        if (Random.Range (0, 2) == 0) {
			audios[3].PlayOneShot(audios[3].clip);
		} else {
			audios[4].PlayOneShot(audios[4].clip);
		}
    }
    
    private void Damaged() {
        currentHealth--;

        if (!dying) {
            StartCoroutine(flashWhenTakingDamage());
        }

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
			FadeAndSuicide();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.gameObject.tag.Equals("Plant") || other.gameObject.tag.Equals("Shooter"))
            && other.gameObject.transform.position.x < gameObject.transform.position.x) {
            eating = other.gameObject.GetComponent<PlantDamageScript>();
            StopMovingStartEating();
        }
    }

    private void FadeAndSuicide() {
        iTween.ColorTo(sprite.gameObject, iTween.Hash(
            "a", 0.0f,
            "delay", 4.0f,
            "time", 2.0f,
            "oncomplete", "Suicide",
            "oncompletetarget", gameObject));
    }

    private void Suicide() {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().unregisterEnemy(gameObject);
        Destroy(gameObject);
    }

    public void StopMovingStartEating() {
        rigid.velocity = Vector2.zero;
        isMoving = false;
        animator.SetBool("Eating", true);
        InvokeRepeating("Eat", 1f, 0.5f);
    }

    public void Eat() {
        if (eating != null) {
			eating.Damaged();
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
        animator.SetBool("Eating", false);
		if (eatSound != null) {
			eatSound.Stop();
			eatSound = null;
		}
        isMoving = true;
    }

    IEnumerator flashWhenTakingDamage() {
        sprite.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.05f);
        sprite.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(0.05f);
        sprite.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.4f);
        yield return new WaitForSeconds(0.05f);
        sprite.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f);
    }

}