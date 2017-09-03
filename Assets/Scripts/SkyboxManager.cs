using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour {

    [SerializeField]
    private Material daytimeSkybox;

    [SerializeField]
    private Material nightimeSkybox;

    [SerializeField]
    private Color darknessAmount;

    [SerializeField]
    private Color sunlightAmount;

    private Light light;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        light.enabled = false;
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
        {
            RenderSettings.skybox = daytimeSkybox;
            light.color = sunlightAmount;
            light.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            RenderSettings.skybox = nightimeSkybox;
            light.color = darknessAmount;
            light.enabled = true;
        }
	}
}
