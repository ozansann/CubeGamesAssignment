using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedValueScript : MonoBehaviour
{
    public static SpeedValueScript instance;
    public Text speedText;
    public float currentSpeedValue;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentSpeedValue = 1.0f;
    }

    public void updateSpeedText(float value)
    {
        speedText.text = "x" + Mathf.RoundToInt(value) + " (Speed)";
        currentSpeedValue = value;                        
    }
}