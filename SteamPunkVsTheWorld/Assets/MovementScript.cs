using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction {Up, Down, Left, Right};

public class MovementScript : MonoBehaviour {

	public Direction direction;
	private Dictionary<Direction, Vector3> directions = new Dictionary<Direction, Vector3>();


	// Use this for initialization
	void Start () {
		directions.Add (Direction.Left, Vector3.left * 0.01f);
		directions.Add (Direction.Right, Vector3.right * 0.05f);
		directions.Add (Direction.Up, Vector3.up * 0.01f);
		directions.Add (Direction.Down, Vector3.down * 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (directions[direction]);
	}
}
