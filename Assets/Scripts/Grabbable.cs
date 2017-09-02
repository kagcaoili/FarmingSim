using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : Interactable {
	

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
