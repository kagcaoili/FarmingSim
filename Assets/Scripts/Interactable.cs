using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private Color originalColor;
    private Color highlightColor = Color.yellow;

    protected bool isInContact = false;
    
    protected SteamVR_TrackedController usedController;

    protected virtual void Start()
    {
        originalColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
    }

    public virtual void OnTriggerStay(Collider col)
    {
        if (!isInContact)
        {
            if (CheckIfController(col.gameObject))
            {
                isInContact = true;
                Highlight();
            }
        }    
    }

    public virtual void OnTriggerExit(Collider col)
    {
        if (isInContact)
        {
            if (CheckIfController(col.gameObject))
            {
                isInContact = false;
                UnHighlight();
            }
        }
    }

    protected virtual bool CheckIfController(GameObject obj)
    {
        SteamVR_TrackedController[] controllers = Manager.instance.GetComponentInChildren<CameraManager>().GetControllers();

        for (int i = 0; i < controllers.Length; i++)
        {
            if (obj == controllers[i].gameObject)
            {
                usedController = controllers[i];
                return true;
            }
        }
        return false;
    }

    protected virtual void Highlight()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", highlightColor);
    }

    protected virtual void UnHighlight()
    {
        gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", originalColor);
    }

}
