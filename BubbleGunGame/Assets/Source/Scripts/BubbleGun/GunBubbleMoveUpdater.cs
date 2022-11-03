using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBubbleMoveUpdater : CycleInitializerBase
{
    [SerializeField] private BubbleGun _bubbleGun;

    public override void OnUpdate()
    {
        BubbleMove bubble = _bubbleGun.BubbleMove;
        if (bubble!=null)
            bubble.Rigidbody.position +=(Vector2)bubble.Direction * bubble.Speed * Time.deltaTime;
    }
}
