using UnityEngine;
using Zenject;

public class BubbleFactoryInstaller : MonoInstaller
{
    [SerializeField] private BubbleFactory _bubblesFactory;
    public override void InstallBindings()
    {
        Container.BindInstance(_bubblesFactory).AsSingle();
    }
}