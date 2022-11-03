using UnityEngine;

[CreateAssetMenu(fileName = "BubblesSizeConfig", menuName = "Config/Bubble/BubblesSizeConfig")]
public class BubblesSizeConfig : ScriptableObject
{
    [SerializeField] private BubblesRepositoryConfig _bubblesRepositoryConfig;
    public float Size => (Camera.main.orthographicSize * 2 * Camera.main.aspect) / _bubblesRepositoryConfig.Size.x;

}
