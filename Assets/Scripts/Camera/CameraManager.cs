using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraManager : MonoBehaviour {

    public GameObject mainController;
    public SteamVR_TrackedController[] controllers;

    [SerializeField] private GameObject ComputerController;
    [SerializeField] private GameObject ViveController;

	// Use this for initialization
	void Start () {
        ComputerController.SetActive(false);
        ViveController.SetActive(false);

        if (VRDevice.isPresent)
        {
            ViveController.SetActive(true);
            mainController = ViveController;
            Manager.instance.isVREnabled = true;
            controllers = GetControllers();
        }
        else
        {
            ComputerController.SetActive(true);
            mainController = ComputerController;
            Manager.instance.isVREnabled = false;
        }

        Debug.Log("Detecting: " + mainController.name);
	}
	
	public SteamVR_TrackedController[] GetControllers()
    {
        if (GetComponentsInChildren<SteamVR_TrackedController>(true) == null)
        {
            SteamVR_TrackedObject[] obj = GetComponentsInChildren<SteamVR_TrackedObject>();
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].gameObject.AddComponent<SteamVR_TrackedController>();
            }
        }
        return GetComponentsInChildren<SteamVR_TrackedController>(true);
    }
}
