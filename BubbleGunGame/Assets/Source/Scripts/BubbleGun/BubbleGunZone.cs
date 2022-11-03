using UnityEngine;

[CreateAssetMenu(fileName = "BubbleGunZone", menuName = "Config/Bubble/BubbleGunZone")]
public class BubbleGunZone : ScriptableObject
{
    [SerializeField] private float _height;
    public float Height => _height;
}
