using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;



public class Buttons : MonoBehaviour {

	public delegate void onActionPress(GameObject unit, bool state);

	public event onActionPress onPress;
	EventTrigger eventTrigger;


	void start()
	{
		Debug.Log(this.gameObject.name);
		eventTrigger = this.gameObject.GetComponent<EventTrigger>();

		addEventTrigger(onPointDown, EventTriggerType.PointerDown);
		addEventTrigger(onPointUp, EventTriggerType.PointerUp);

	}

	void addEventTrigger(UnityAction action, EventTriggerType triggerType)
	{
		EventTrigger.TriggerEvent trigger = new EventTrigger.TriggerEvent();
		trigger.AddListener((eventData) => action());
		EventTrigger.Entry entry = new EventTrigger.Entry(){callback = trigger, eventID = triggerType};
		eventTrigger.triggers.Add(entry);
	}

	void onPointDown()
	{
		if (onPress != null)  
		{
			onPress(this.gameObject, true);
		}

	}

	void onPointUp()
	{
		if (onPress != null) 
		{
			onPress(this.gameObject, false);
		}	
	}
}
