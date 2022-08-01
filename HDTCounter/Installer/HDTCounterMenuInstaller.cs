using HDTCounter.Views;
using Zenject;

namespace HDTCounter.Installer
{
    public class HDTCounterMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<SettingTabViewController>().FromNewComponentAsViewController().AsSingle().NonLazy();
        }
    }
}
