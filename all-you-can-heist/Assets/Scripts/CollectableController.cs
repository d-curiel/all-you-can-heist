using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableController : MonoBehaviour
{
    public abstract LootingData Loot();
}
