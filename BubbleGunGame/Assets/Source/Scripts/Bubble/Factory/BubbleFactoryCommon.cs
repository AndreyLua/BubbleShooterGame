using UnityEngine;
using Zenject;

public class BubbleFactoryCommon : BubbleFactoryBehaviourBase
{
    [Inject]
    private BubbleBehaviourTypeConfig _bubbleBehaviourTypeConfig;
    [Inject]
    private BubbleSkinTypeConfig _bubbleSkinTypeConfig;
    [Inject]
    private BubblesSizeConfig _bubblesSizeConfig;

    public override BubbleType Type => BubbleType.Common;
    public override TBubble Create<TBubble>(BubbleType bubbleType, BubbleSkinID bubbleSkinID, Vector2 position)
    {
        TBubble bubbleBase = (TBubble)_bubbleBehaviourTypeConfig.BubbleBehaviourTypePairs[bubbleType];
        BubbleSkin bubbleSkin = _bubbleSkinTypeConfig.BubbleSkinTypePairs[bubbleSkinID];

        TBubble bubblePrefab = Instantiate<TBubble>(bubbleBase, position, Quaternion.identity);
        BubbleSkin bubbleSkinPrefab = Instantiate<BubbleSkin>(bubbleSkin, position, Quaternion.identity);

        bubbleSkinPrefab.transform.localScale = new Vector2(_bubblesSizeConfig.Size, _bubblesSizeConfig.Size);
   
        bubblePrefab.SetSkin(bubbleSkinPrefab, _bubblesSizeConfig);

        return bubblePrefab;
    }
}
