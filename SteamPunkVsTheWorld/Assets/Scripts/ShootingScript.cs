using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public GameObject bullet;
    public int orderInLayer;
    private bool shooting = false;
    private Animator animator;

    // Use this for initialization
    void Start() {
        orderInLayer = gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder + 2;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    void Shoot() {
        GameObject tempBullet = (GameObject)Instantiate(bullet, transform.position + Vector3.right, Quaternion.identity);
        tempBullet.GetComponentInChildren<SpriteRenderer>().sortingOrder = orderInLayer;
    }

    void StartShooting() {
        if (!shooting) {
            InvokeRepeating("Shoot", 0.6f, 1.6f);
            if (animator == null) {
                animator = gameObject.GetComponentInChildren<Animator>();
            }
            shooting = true;
            animator.runtimeAnimatorController = Resources.Load("ShooterShooting") as RuntimeAnimatorController;
        }
    }

    void Stop() {
        if (shooting) {
            CancelInvoke();
            shooting = false;
            StartCoroutine(randomizeAnimationStart());
        }


    }

    IEnumerator randomizeAnimationStart() {
        yield return new WaitForSeconds(Random.Range(0.0f, 1.5f));
        if (!shooting) {
            animator.runtimeAnimatorController = Resources.Load("ShooterIdling") as RuntimeAnimatorController;
        }
    }

}
