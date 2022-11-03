using UnityEngine;

[CreateAssetMenu(fileName = "BubblesRepositoryConfig", menuName = "Config/Bubble/BubblesRepositoryConfig")]
public class BubblesRepositoryConfig : ScriptableObject
{
    [SerializeField] private Vector2Int _size;
    public Vector2Int Size => _size;
}
