﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResourceManager : MonoBehaviour {

	private static int startingResources = 2;
	private static int resources = startingResources;
	private static Dictionary<Plant,int> plantPrices = new Dictionary<Plant,int>();

	// Use this for initialization
	void Start () {
		if (plantPrices.Count < 3) {
			plantPrices.Add (Plant.Producer, 2);
			plantPrices.Add (Plant.Shooter, 4);
			plantPrices.Add (Plant.Blocker, 2);
			plantPrices.Add (Plant.Eater, 6);
			plantPrices.Add (Plant.DoubleShooter, 8);
		}
	}

	public static void reset(){
		resources = startingResources;
	}

	public static void addResources(int amount){
		resources += amount;
	}

	public static void reduceResources(int amount){
		resources -= amount;
	}

	public static int getResources(){
		return resources;
	}

	public static int getPlantPrice(Plant plant){
		return plantPrices[plant];
	}

	public static void buyPlant(Plant plant){
		reduceResources (getPlantPrice(plant));
	}
}
