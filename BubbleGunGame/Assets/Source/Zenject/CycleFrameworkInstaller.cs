using UnityEngine;
using Zenject;

public class CycleFrameworkInstaller : MonoInstaller
{
    [SerializeField] private  CycleFramework _cycleFramework;
    public override void InstallBindings()
    {
        Container.BindInstance(_cycleFramework).AsSingle();
    }
}