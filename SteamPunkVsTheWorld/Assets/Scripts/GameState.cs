﻿using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int level = 0;
	private static int maxLevel = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void levelUp(){
		level++;
		if (level > maxLevel) {
			level = maxLevel;
		}
	}
}