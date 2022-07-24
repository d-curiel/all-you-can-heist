using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    private int keys = 1;
    public int Keys { get; set; }
}
