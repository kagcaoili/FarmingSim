using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private Color originalColor;
    private Color highlightColor = Color.yellow;

    protected bool isInContact = false;

    protected virtual void Start()
    {
        originalColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        Debug.Log("OriginalColor is : " + originalColor);
    }

    public virtual void OnTriggerStay(Collider col)
    {
        if (!isInContact)
        {
            Highlight();
        }
    }

    public virtual void OnTriggerExit(Collider col)
    {
        if (isInContact)
        {
            UnHighlight();
        }
    }

    private void Highlight()
    {
        isInContact = true;
        gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", highlightColor);
    }

    private void UnHighlight()
    {
        isInContact = false;
        gameObject.GetComponentInChildren<MeshRenderer>().material.SetColor("_Color", originalColor);
    }

}
