using System;
using UnityEngine;

public abstract class BubbleMove : BubbleBase
{
    public event Action Arrived;


    public Vector3 Direction { get; private set; }
    public float Speed { get; private set; }

    public void SetSpeed(float value)
    {
        Speed = value;
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Bound>(out Bound bound))
        {
            if (collision.gameObject.TryGetComponent<UpperBound>(out UpperBound upperBound))
            {
                SendArrivedEvent();
                return;
            }
            Vector3 newDirection = Vector3.Reflect(Direction, collision.contacts[0].normal);
            Direction = newDirection;
            return;
        }
        if (collision.gameObject.TryGetComponent<BubbleBase>(out BubbleBase bubble))
        {
            SendArrivedEvent();
            return;
        }
        throw new Exception("Collision with unfamiliar object");
    }

    private void SendArrivedEvent()
    {
        if (this.State == BubbleState.Move)
            Arrived?.Invoke();
    }
}
