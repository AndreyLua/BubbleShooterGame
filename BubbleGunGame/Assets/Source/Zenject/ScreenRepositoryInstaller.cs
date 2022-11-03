using UnityEngine;
using Zenject;

public class ScreenRepositoryInstaller : MonoInstaller
{
    [SerializeField] private ScreenRepository _screenRepository; 
    public override void InstallBindings()
    {
        Container.BindInstance(_screenRepository).AsSingle();
    }
}