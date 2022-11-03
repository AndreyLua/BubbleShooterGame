using UnityEngine;
using Zenject;

[DefaultExecutionOrder(-100)]
public class ConfigsInstaller : MonoInstaller
{
    [SerializeField] private BubbleSkinTypeConfig _bubbleSkinTypeConfig;
    [SerializeField] private BubbleBehaviourTypeConfig _bubbleBehaviourTypeConfig;
    [SerializeField] private BubblesRepositoryConfig _repositoryConfig;
    [SerializeField] private BubblesSizeConfig _bubblesSizeConfig;
  
    public override void InstallBindings()
    {
        Container.BindInstance(_bubblesSizeConfig).AsSingle();
        Container.BindInstance(_bubbleSkinTypeConfig).AsSingle();
        Container.BindInstance(_bubbleBehaviourTypeConfig).AsSingle();
        Container.BindInstance(_repositoryConfig).AsSingle();
    }
}