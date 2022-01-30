using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    private Slider _slider;

    protected void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected void OnValueChanged(int value, int maxValue)
    {
        _slider.value = (float)value / maxValue;
    }
}
