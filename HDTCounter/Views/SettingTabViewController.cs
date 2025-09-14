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
        private GameplaySetup _gameplaySetup;
        [Inject]
        private void Constractor(GameplaySetup gameplaySetup)
        {
            this._gameplaySetup = gameplaySetup;
        }

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
                if (PluginConfig.Instance.BpFactor.Equals(value))
                    return;
                if (value < 1f)
                    value = 1f;
                PluginConfig.Instance.BpFactor = value;
                NotifyPropertyChanged();
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

        [UIAction("FactorMinus10")]
        private void FactorMinus10()
        {
            this.BpFactor -= 10f;
        }

        [UIAction("FactorPlus10")]
        private void FactorPlus10()
        {
            this.BpFactor += 10f;
        }
        protected override void OnDestroy()
        {
            this._gameplaySetup.RemoveTab(TabName);
            base.OnDestroy();
        }

        public void Initialize()
        {
            this._gameplaySetup.AddTab(TabName, this.ResourceName, this);
        }
    }
}
