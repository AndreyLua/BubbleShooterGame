using System;
using UnityEngine;
using Zenject;

public class BubbleRepositoryInserter : CycleInitializerBase
{
    [SerializeField] private BubbleGun _bubbleGun;
    [Inject]
    private BubblesRepository _bubblesRepository;

    public event Action<BubbleMove> NewBubbleInRepository;

    public override void OnInit()
    {
        _bubbleGun.Shooted += OnShooted;
    }

    private void OnShooted()
    {
        _bubbleGun.BubbleMove.Arrived += OnArrived;
    }

    private void OnArrived()
    {
        BubbleMove bubble = _bubbleGun.BubbleMove;
        bubble.SetSpeed(0);
        bubble.SetState(BubbleState.Stand);
        Vector2Int bubbleRepositoryCoordinate = _bubblesRepository.GetRepositioryCoordinate(bubble.transform.position);
        bubble.Rigidbody.position = _bubblesRepository.GetWorldCoordinate(bubbleRepositoryCoordinate);
        NewBubbleInRepository?.Invoke(bubble);
    }
}
