using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "BubbleSkinTypeConfig", menuName = "Config/Bubble/BubbleSkinTypeConfig")]
public class BubbleSkinTypeConfig : ScriptableObject
{
    [SerializeField] private BubbleSkin[] _skins;
    private Dictionary<BubbleSkinID, BubbleSkin> _bubbleSkinTypePairs;
    public Dictionary<BubbleSkinID, BubbleSkin> BubbleSkinTypePairs => _bubbleSkinTypePairs;

    private void OnEnable()
    {
        _bubbleSkinTypePairs = _skins.ToDictionary(skin => skin.ID, skin => skin);
    }
}
