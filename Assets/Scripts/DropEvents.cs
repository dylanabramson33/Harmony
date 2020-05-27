using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEvents : MonoBehaviour
{
    public static DropEvents current;

    [Header("Standard Bird Interactions")]
    public ObjectType standardBird;
    public ObjectType[] validStandardBirdSurfaces;



    void Awake()
    {
        current = this;
    }

    public void DropIfAble(ObjectType drop, ObjectType onto, ObjectType[] list)
    {
        foreach(ObjectType potential in list)
        {
            if(potential == onto)
            {
                onObjectDropped?.Invoke(drop);
            }
        }
    }

    public event Action<ObjectType> onObjectDropped;
    public void DropObject(ObjectType droppedObjectType, ObjectType ontoObjectType)
    {
        switch (droppedObjectType)
        {
            case (ObjectType.Bird):
                DropIfAble(droppedObjectType, ontoObjectType, validStandardBirdSurfaces);
                break;
            default:
                break; 
        }
                


       
    }

   
}
