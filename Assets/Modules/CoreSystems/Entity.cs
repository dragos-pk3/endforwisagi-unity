using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public virtual void DestroyEntity()
    {
        Destroy(gameObject);
    }
}


