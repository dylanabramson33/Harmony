using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabEvents : MonoBehaviour
{
    public static GrabEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action<ObjectType> onObjectGrabbed;
    public void GrabObject(ObjectType objectType)
    {
        onObjectGrabbed?.Invoke(objectType);
    }

   
}
