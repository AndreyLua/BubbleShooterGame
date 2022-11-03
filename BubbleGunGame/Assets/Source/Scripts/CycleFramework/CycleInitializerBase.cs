using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CycleInitializerBase : MonoBehaviour
{
    public virtual void OnInit() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
}
