using System;
using UnityEngine;
using Zenject;

public class BubbleGun : CycleInitializerBase
{
    [SerializeField] private BubbleGunZone _bubbleGunZone;
    [SerializeField] private BubblesSizeConfig _bubblesSizeConfig;
    [SerializeField] private GunBubblesConfig _bubblesGunConfig;
    [SerializeField] private float _bubbleSpeed;

    [Inject]
    private BubbleFactory _bubblesFactory;
    private GunBubbleArray _gunBubbleArray;
    private BubbleMove _bubbleMove;

    public event Action Shooted;
    public BubbleMove BubbleMove => _bubbleMove;

    public override void OnInit()
    {
        _gunBubbleArray = new GunBubbleArray(_bubblesGunConfig);
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.pixelWidth / 2, 0)) + new Vector3(0, _bubbleGunZone.Height, 0) + new Vector3(0, _bubblesSizeConfig.Size, 0);
        Reload();
    }

    private bool InGameZone(Vector3 position)
    {
        return Camera.main.ScreenToWorldPoint(position).y > gameObject.transform.position.y;
    }

    private void Reload()
    {
        BubbleMove bubble = _gunBubbleArray.GetBubble();
        _bubbleMove = _bubblesFactory.Create<BubbleMove>(bubble.Type, bubble.SkinID, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0));
    }

    private void Shoot(Vector3 direction)
    {
        _bubbleMove.SetState(BubbleState.Move);
        _bubbleMove.SetDirection(direction);
        _bubbleMove.SetSpeed(_bubbleSpeed);
    }

    public override void OnUpdate()
    {
        if (_bubbleMove == null)
            Reload();

        if (Input.GetMouseButtonUp(0) && InGameZone(Input.mousePosition))
        {
            if (_bubbleMove.State==BubbleState.Stand)
            {
                Shoot((Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position).normalized);
                Shooted?.Invoke();
            }
        }
    }

}