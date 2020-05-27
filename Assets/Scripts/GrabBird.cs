using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBird : MonoBehaviour, IInteractable
{
    
    [SerializeField] private ObjectType objectType = default;

    public void Interaction()
    {
        GrabEvents.current.GrabObject(objectType);
        Destroy(gameObject);
    }

    
}
