using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "BubbleBehaviourTypeConfig", menuName = "Config/Bubble/BubbleBehaviourTypeConfig")]
public class BubbleBehaviourTypeConfig : ScriptableObject
{
    [SerializeField] BubbleBase[] _bubbles;
    private Dictionary<BubbleType, BubbleBase> _bubbleBehaviourTypePairs;
    public Dictionary<BubbleType, BubbleBase> BubbleBehaviourTypePairs => _bubbleBehaviourTypePairs;

    private void OnEnable()
    {
        _bubbleBehaviourTypePairs = _bubbles.ToDictionary(bubble => bubble.Type, bubble => bubble);
    }
}
