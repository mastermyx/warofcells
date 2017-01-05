using System.Collections;
using UnityEngine;

public class MouvementController : MonoBehaviour {

	public Buttons left;
	public Buttons right;
	public Buttons boost;

	[HideInInspector]
	public GameObject playerObj;

	public bool leftMoveBool;
	public bool rightMoveBool;
	public bool boostMoveBool;

	public void actionMouvemen()
	{
		left.onPress += onPress;
		right.onPress += onPress;
		boost.onPress += onPress;
	}


	void onPress(GameObject unit, bool state)
	{
		switch (unit.name) 
		{
		case "left":
			leftMove(state);
			break;
		case "right":
			rightMove(state);
			break;
		case "boost":
			boostMove(state);
			break;
		}

		Debug.Log(unit.name);

	}

	private void leftMove(bool state)
	{
		leftMoveBool = state;
	}
	private void rightMove(bool state)
	{
		rightMoveBool = state;
	}
	private void boostMove(bool state)
	{
		boostMoveBool = state;
	}



	void Update () {
		
	}
}
