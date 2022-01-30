using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] private Enemy _template;
    [SerializeField] private int _volume;
    [SerializeField] private float _delay;

    public Enemy Template => _template;
    public int Volume => _volume;

    public float Delay => _delay;
}
