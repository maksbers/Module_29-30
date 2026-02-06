using System;
using UnityEngine;

[Serializable]
public class OrkConfig
{
    [field: SerializeField] public int Damage { get; private set; } = 20;
    [field: SerializeField] public int Strength { get; private set; } = 40;
}
