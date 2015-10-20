using UnityEngine;
using System.Collections;

public class DoubleShootingScript : MonoBehaviour {
	
	public GameObject bullet;
	public int orderInLayer;
	private bool shooting = false;
	private Animator animator;
	private AudioSource shootingsfx;
	private ParticleSystem shootingvfx;
	
	// Use this for initialization
	void Start() {
		orderInLayer = gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder + 2;
		animator = gameObject.GetComponentInChildren<Animator>();
		shootingsfx = gameObject.GetComponent<AudioSource>();
		shootingvfx = transform.FindChild("Shootingvfx").GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	void Shoot() {
		StartCoroutine (DoubleShoot ());
	}

	IEnumerator DoubleShoot() {
		GameObject tempBullet = (GameObject)Instantiate(bullet, (transform.position + Vector3.right/2), Quaternion.identity);
		tempBullet.GetComponentInChildren<SpriteRenderer>().sortingOrder = orderInLayer;
		shootingvfx.Emit(1);
		shootingsfx.Play();
		
		yield return new WaitForSeconds(0.417f);
		
		tempBullet = (GameObject)Instantiate(bullet, (transform.position + Vector3.right/2 + Vector3.down/2), Quaternion.identity);
		tempBullet.GetComponentInChildren<SpriteRenderer>().sortingOrder = orderInLayer;
		
		shootingvfx.Emit(1);
		shootingsfx.Play();
	}
	
	void StartShooting() {
		if (!shooting) {
			shooting = true;
			StartCoroutine(randomizeShootingStart());
		}
	}
	
	void Stop() {
		if (shooting) {
			CancelInvoke();
			shooting = false;
			StartCoroutine(randomizeIdleAnimationStart());
		}
	}
	
	IEnumerator randomizeIdleAnimationStart() {
		yield return new WaitForSeconds(Random.Range(0.00f, 0.99f));
		if (!shooting) {
			animator.SetBool ("Shooting", false);
		}
	}
	
	IEnumerator randomizeShootingStart() {
		yield return new WaitForSeconds(Random.Range(0.00f, 0.99f));
		InvokeRepeating("Shoot", 0.6f, 1.667f);
		if (animator == null) {
			animator = gameObject.GetComponentInChildren<Animator>();
		}
		if (shootingvfx == null) {
			transform.FindChild("Shootingvfx").GetComponent<ParticleSystem>();
		}
		if (shooting) {
			animator.SetBool("Shooting", true);
		}
	}
	
}
