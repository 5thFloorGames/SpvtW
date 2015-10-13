using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResourceScript : MonoBehaviour {

	private static int resources = 1500;
	private static Dictionary<Plant,int> plantPrices = new Dictionary<Plant,int>();


	// Use this for initialization
	void Start () {
		plantPrices.Add (Plant.Producer, 50);
		plantPrices.Add (Plant.Shooter, 100);
		plantPrices.Add (Plant.Blocker, 50);
	}
	
	// Update is called once per frame
	void Update () {
	
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
