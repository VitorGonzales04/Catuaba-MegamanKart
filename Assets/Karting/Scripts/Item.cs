using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public string description;
    public int Uses;

    public ItemBoostFunction[] Boost;

    public Sprite Visual;
}