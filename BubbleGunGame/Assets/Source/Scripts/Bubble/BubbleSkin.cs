using UnityEngine;

public class BubbleSkin:MonoBehaviour
{
    [SerializeField] private Transform _bubble;
    [SerializeField] private BubbleSkinID _id;
    public BubbleSkinID ID => _id;
    public Transform Bubble => _bubble;
}
