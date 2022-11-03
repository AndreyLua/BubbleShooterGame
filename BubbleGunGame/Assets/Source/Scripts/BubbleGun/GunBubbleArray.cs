using System.Collections.Generic;
using UnityEngine;

public class GunBubbleArray
{
    private IReadOnlyList<BubbleMove> _bubbleBases;
    private int _bubbleBaseIndex = 0;

    public GunBubbleArray(GunBubblesConfig bubblesGunConfig)
    {
        _bubbleBases = bubblesGunConfig.Bubbles;
    }

    public BubbleMove GetBubble()
    {
        _bubbleBaseIndex = _bubbleBaseIndex + 1;
        if (_bubbleBaseIndex < _bubbleBases.Count)
        {
            return _bubbleBases[_bubbleBaseIndex];
        }
        else
        {
            _bubbleBaseIndex = 0;
            return _bubbleBases[_bubbleBaseIndex];
        }
    }
}
