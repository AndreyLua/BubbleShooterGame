using UnityEngine;

public abstract class BubbleBase : MonoBehaviour
{
    [SerializeField] private BubbleSkin _skin;
    private float _size;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody;
    private BubbleState _state;

    public Rigidbody2D Rigidbody => _rigidbody;
    public BubbleState State => _state;
    public BubbleSkin Skin => _skin;
    public float Size => _size;

    public abstract BubbleType Type { get; }
    public BubbleSkinID SkinID => _skin.ID;

    private void Awake()
    {
        _state = BubbleState.Stand;
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetState( BubbleState state)
    {
        _state = state;
    }

    public void SetSkin(BubbleSkin skinPrefab, BubblesSizeConfig sizeConfig)
    {
        _size = sizeConfig.Size;

        _skin = gameObject.GetComponentInChildren<BubbleSkin>();
        Destroy(_skin.gameObject);
        _skin = skinPrefab;
        skinPrefab.transform.parent = gameObject.transform;
    }
}
