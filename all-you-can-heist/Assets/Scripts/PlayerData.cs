using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int keys;
    [SerializeField]
    private int gold;
    public int Keys { get; set; }
    public int Gold { get; set; }
}
