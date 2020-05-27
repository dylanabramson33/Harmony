using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBirdOnWater : MonoBehaviour, IPlaceable
{
    public ObjectType ReturnObjectType()
    {
        return ObjectType.Water;
    }
}
