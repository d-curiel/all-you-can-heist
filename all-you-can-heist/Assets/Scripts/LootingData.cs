using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Looting Data")]
public class LootingData : ScriptableObject
{
    [SerializeField]
    private int key;
    [SerializeField]
    private int gold;

    public int Key()
    {
        return key;
    }

    public int Gold()
    {
        return gold;
    }
}
