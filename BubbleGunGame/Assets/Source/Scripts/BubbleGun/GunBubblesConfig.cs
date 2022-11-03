using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunBubblesConfig", menuName = "Config/Bubble/GunBubblesConfig")]
public class GunBubblesConfig : ScriptableObject
{
    [SerializeField] private List<BubbleMove> _bubbles;
    public IReadOnlyList<BubbleMove> Bubbles => _bubbles; 
}
