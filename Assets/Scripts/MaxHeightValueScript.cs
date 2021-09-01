using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHeightValueScript : MonoBehaviour
{
    public static MaxHeightValueScript instance;
    public Text maxHeightText;
    public float currentMaxHeightValue;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentMaxHeightValue = 10.0f;   
    }

    public void updateMaxHeightText(float value)
    {
        maxHeightText.text = Mathf.RoundToInt(value) + " (hmax)";
        currentMaxHeightValue = value;
    }
}