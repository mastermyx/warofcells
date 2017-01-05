using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;


public class Controller : MonoBehaviour {


	public SocketIOComponent socket;


	// Use this for initialization
	void Start() 
	{
		StartCoroutine(connectToServer());
		socket.On("USER_CONNECTED", onUserConnected);
	}

	IEnumerator connectToServer()
	{
		yield return new WaitForSeconds (0.5f);

		socket.Emit("USER_CONNECT");

		yield return new WaitForSeconds(1f);

		Dictionary<string, string> data = new Dictionary<string, string> ();
		data["name"] = "Arthur";

		Vector3 position = new Vector3 (0, 0, 0);
		data ["position"] = position.x + "," + position.y + "," + position.z;
		socket.Emit ("PLAY", new JSONObject(data));
	}

	private void onUserConnected(SocketIOEvent evt) 
	{
		Debug.Log("Get the message from server: " + evt.data + " onUserConnected");
	}

	private void onUserPlay(SocketIOEvent evt)
	{
		Debug.Log("Get the message from server: " + evt.data + " onUserPlay");
	}
}
