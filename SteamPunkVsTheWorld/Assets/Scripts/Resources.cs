using UnityEngine;
using System.Collections;

public class Resources : MonoBehaviour {

	private static int resources = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void addResources(int amount){
		resources += amount;
	}

	public static int getResources(){
		return resources;
	}
}
