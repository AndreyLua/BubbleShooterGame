using UnityEngine;

public abstract class BubbleFactoryBehaviourBase : MonoBehaviour
{
    public abstract BubbleType Type { get; }
    public abstract TBubble Create<TBubble>(BubbleType bubbleType, BubbleSkinID bubbleSkin, Vector2 position) where TBubble : BubbleBase;
}


