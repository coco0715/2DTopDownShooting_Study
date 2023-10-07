using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int MaxHealth;
    [Range(1f, 20)] public float Speed;
}
