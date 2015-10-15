﻿using UnityEngine;
using System.Collections;

public class CatMove : MonoBehaviour {
	
	private Rigidbody2D rigid;
	
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D>();
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
	}
	
	// Update is called once per frame
	void Update () {
		print (rigid.velocity);
	}
	
	public void Stop(){
		rigid.velocity = Vector2.zero;
	}
	
	public void Go(){
		rigid.MovePosition(transform.position + (Vector3.left * (0.15f) * Time.deltaTime));
	}
}
