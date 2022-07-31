using BeatSaberMarkupLanguage.Attributes;
using HDTCounter.Configuration;
using System.Globalization;

namespace HDTCounter
{
    internal class SettingsHandler
    {
        [UIValue("DecimalPrecision")]
        public int DecimalPrecision
        {
            get => PluginConfig.Instance.DecimalPrecision;
            set
            {
                PluginConfig.Instance.DecimalPrecision = value;
            }
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

        [UIValue("EnableLabel")]
        public bool EnableLabel
        {
            get => PluginConfig.Instance.EnableLabel;
            set
            {
                PluginConfig.Instance.EnableLabel = value;
            }
        }

        [UIValue("LabelFontSize")]
        public float LabelFontSize
        {
            get => PluginConfig.Instance.LabelFontSize;
            set
            {
                PluginConfig.Instance.LabelFontSize = value;
            }
        }

        [UIValue("FigureFontSize")]
        public float FigureFontSize
        {
            get => PluginConfig.Instance.FigureFontSize;
            set
            {
                PluginConfig.Instance.FigureFontSize = value;
            }
        }

        [UIValue("OffsetX")]
        public float OffsetX
        {
            get => PluginConfig.Instance.OffsetX;
            set
            {
                PluginConfig.Instance.OffsetX = value;
            }
        }

        [UIValue("OffsetY")]
        public float OffsetY
        {
            get => PluginConfig.Instance.OffsetY;
            set
            {
                PluginConfig.Instance.OffsetY = value;
            }
        }

        [UIValue("OffsetZ")]
        public float OffsetZ
        {
            get => PluginConfig.Instance.OffsetZ;
            set
            {
                PluginConfig.Instance.OffsetZ = value;
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
    }
}
