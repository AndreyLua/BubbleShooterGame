using UnityEngine;
using Zenject;

public class BubbleRepositoryInstaller : MonoInstaller
{
    private BubblesRepository _bubblesRepository;
    public override void InstallBindings()
    {
        _bubblesRepository = new BubblesRepository(Container.Resolve<BubblesRepositoryConfig>(), Container.Resolve<BubbleFactory>(), Container.Resolve<BubblesSizeConfig>());
        Container.BindInstance(_bubblesRepository).AsSingle();
    }
}