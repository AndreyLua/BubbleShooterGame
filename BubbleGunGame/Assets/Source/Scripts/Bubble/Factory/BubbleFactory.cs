using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BubbleFactory : MonoBehaviour
{
    [SerializeField] private BubbleFactoryBehaviourBase[] _factories;
    private Dictionary<BubbleType, BubbleFactoryBehaviourBase> _bubbleFactoryBehaviourTypePairs;

    private void Awake()
    {
        _bubbleFactoryBehaviourTypePairs = _factories.ToDictionary(bubbleFactory => bubbleFactory.Type, bubbleFactory => bubbleFactory);
    }

    public TBubble Create<TBubble>( BubbleType bubbleType, BubbleSkinID skinID,Vector2 position) where TBubble:BubbleBase
    {
        BubbleFactoryBehaviourBase factoryBehavior = _bubbleFactoryBehaviourTypePairs[bubbleType];
        return factoryBehavior.Create<TBubble>(bubbleType, skinID, position);
    }
}
