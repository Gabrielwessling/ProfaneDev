using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    GameObject playerObject;
    public static float lookSensitivity;

    public Slider lookSenseSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lookSensitivity = lookSenseSlider.value;
        lookSenseSlider.value = lookSensitivity;
        playerObject.GetComponent<FPSControl>().lookSpeed = lookSensitivity;
    }
}
