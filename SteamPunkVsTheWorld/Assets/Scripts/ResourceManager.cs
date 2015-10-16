using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResourceManager : MonoBehaviour {

	private static int resources = 20;
	private static Dictionary<Plant,int> plantPrices = new Dictionary<Plant,int>();


	// Use this for initialization
	void Start () {
		if (plantPrices.Count < 3) {
			plantPrices.Add (Plant.Producer, 2);
			plantPrices.Add (Plant.Shooter, 4);
			plantPrices.Add (Plant.Blocker, 2);
		}
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
