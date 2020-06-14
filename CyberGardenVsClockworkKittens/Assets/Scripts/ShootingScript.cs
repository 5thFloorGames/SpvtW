using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public GameObject bullet;
    public int orderInLayer;
    private bool shooting = false;
    private Animator animator;
    private AudioSource shootingsfx;
    private ParticleSystem shootingvfx;
	
    void Start() {
        orderInLayer = gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder + 2;
        animator = gameObject.GetComponentInChildren<Animator>();
        shootingsfx = gameObject.GetComponent<AudioSource>();
        shootingvfx = transform.Find("Shootingvfx").GetComponent<ParticleSystem>();
    }

    void Shoot() {
        GameObject tempBullet = (GameObject)Instantiate(bullet, (transform.position + Vector3.right/2), Quaternion.identity);
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
            animator.runtimeAnimatorController = Resources.Load("ShooterIdling") as RuntimeAnimatorController;
        }
    }

    IEnumerator randomizeShootingStart() {
        yield return new WaitForSeconds(Random.Range(0.00f, 0.99f));
        InvokeRepeating("Shoot", 0.6f, 1.6f);
        if (animator == null) {
            animator = gameObject.GetComponentInChildren<Animator>();
        }
        if (shootingvfx == null) {
            transform.Find("Shootingvfx").GetComponent<ParticleSystem>();
        }
        if (shooting) {
            animator.runtimeAnimatorController = Resources.Load("ShooterShooting") as RuntimeAnimatorController;
        }
    }

}
