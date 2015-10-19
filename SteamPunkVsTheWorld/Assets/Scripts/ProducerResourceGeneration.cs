using UnityEngine;
using System.Collections;

public class ProducerResourceGeneration : MonoBehaviour {
	private Animator animator;

	public GameObject resource;

	void Start () {
		InvokeRepeating("OrbProduction", 1, 24);
		animator = gameObject.GetComponentInChildren<Animator>();
	}

	void Update () {
		
	}

    void OrbProduction() {
        StartCoroutine(animationTiming());
    }

	IEnumerator animationTiming() {
        animator.SetBool("OrbGenerated", false);
        animator.SetTrigger("LightingUp");
        yield return new WaitForSeconds(4);
        createAnOrb();
        yield return new WaitForSeconds(1);
        animator.SetBool("OrbGenerated", true);
    }
	
	void createAnOrb() {
		GameObject spawned = (GameObject)Instantiate (resource, transform.position + new Vector3(0f,0f,-1f), Quaternion.identity);
		ResourceObjectLogic crf = spawned.GetComponent<ResourceObjectLogic>();
        crf.globalResource = false;
	}
}