using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class CameraManager : MonoBehaviour {

    public GameObject mainController;

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
        }
        else
        {
            ComputerController.SetActive(true);
            mainController = ComputerController;
        }

        Debug.Log("Detecting: " + mainController.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
