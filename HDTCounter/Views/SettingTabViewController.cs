using HDTCounter.Configuration;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using BeatSaberMarkupLanguage.ViewControllers;
using System.Globalization;
using Zenject;

namespace HDTCounter.Views
{
    [HotReload]
    internal class SettingTabViewController : BSMLAutomaticViewController, IInitializable
    {
        public const string TabName = "HDT Counter";
        public string ResourceName => string.Join(".", GetType().Namespace, GetType().Name);
        [UIValue("EnableBp")]
        public bool EnableBp
        {
            get => PluginConfig.Instance.EnableBp;
            set
            {
                PluginConfig.Instance.EnableBp = value;
            }
        }

        [UIValue("BpFactor")]
        public float BpFactor
        {
            get => PluginConfig.Instance.BpFactor;
            set
            {
                PluginConfig.Instance.BpFactor = value;
            }
        }

        [UIValue("BpFailureThreshold")]
        public float BpFailureThreshold
        {
            get => PluginConfig.Instance.BpFailureThreshold;
            set
            {
                PluginConfig.Instance.BpFailureThreshold = value;
            }
        }

        [UIAction("BpFactorFormatter")]
        private string BpFactorFormatter(float value)
        {
            return $"x {value.ToString("F0", CultureInfo.InvariantCulture)}";
        }

        [UIAction("BpFailureThresholdFormatter")]
        private string BpFailureThresholdFormatter(float value)
        {
            return $"{value.ToString("F1", CultureInfo.InvariantCulture)} m";
        }

        protected override void OnDestroy()
        {
            GameplaySetup.instance.RemoveTab(TabName);
            base.OnDestroy();
        }

        public void Initialize()
        {
            GameplaySetup.instance.AddTab(TabName, this.ResourceName, this);
        }
    }
}
