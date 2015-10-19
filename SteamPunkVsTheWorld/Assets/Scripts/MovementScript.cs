using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction {Up, Down, Left, Right};

public class MovementScript : MonoBehaviour {

	public Direction direction;
	private Dictionary<Direction, Vector3> directions = new Dictionary<Direction, Vector3>();

	void Start () {
		directions.Add (Direction.Left, Vector3.left * (0.15f) * Time.deltaTime);
		directions.Add (Direction.Right, Vector3.right * 3f * Time.deltaTime);
		directions.Add (Direction.Up, Vector3.up * 0.5f * Time.deltaTime);
		directions.Add (Direction.Down, Vector3.down * 0.5f * Time.deltaTime);
	}
	
	void Update () {
		transform.Translate (directions[direction]);
	}
}
