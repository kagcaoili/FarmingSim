using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable {

    private bool isTriggerHeld = false;

    public override void OnTriggerStay(Collider col)
    {
        if (!isInContact)
        {
            if (CheckIfController(col.gameObject))
            {
                Highlight();
                isInContact = true;
                usedController.TriggerClicked += HandleTriggerClicked;
                usedController.TriggerUnclicked += HandleTriggerUnclicked;
            }
        }
    }

    public override void OnTriggerExit(Collider col)
    {
        if (isInContact)
        {
            if (CheckIfController(col.gameObject))
            {
                UnHighlight();
                isInContact = false;
                usedController.TriggerClicked -= HandleTriggerClicked;
                usedController.TriggerUnclicked -= HandleTriggerUnclicked;
            }
        }
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        if (!isTriggerHeld)
        {
            isTriggerHeld = true;
            Debug.Log("GRAB the " + gameObject);
            gameObject.transform.parent = usedController.gameObject.transform;
        }   
    }

    private void HandleTriggerUnclicked(object sender, ClickedEventArgs e)
    {
        if (isTriggerHeld)
        {
            isTriggerHeld = false;
            Debug.Log("LET GO the " + gameObject);
            gameObject.transform.parent = null;
        }
    }

    public virtual void OnGrab () {
		if (isInContact)
        {
            Debug.Log("GRAB IT");
        }
	}

    public virtual void OnUnGrab()
    {

    }
}
