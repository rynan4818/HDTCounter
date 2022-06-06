using HeadDistanceTravelled;
using CountersPlus.Counters.Custom;
using System.Globalization;
using TMPro;
using HDTCounter.Configuration;
using UnityEngine;
using Zenject;

namespace HDTCounter
{
    internal class HDTCounter : BasicCustomCounter
    {
        private float x = PluginConfig.Instance.OffsetX;
        private float y = PluginConfig.Instance.OffsetY;
        private float z = PluginConfig.Instance.OffsetZ;
        private TMP_Text _counterHDT;
        private readonly IHeadDistanceTravelledController _controller;

        [Inject]
        public HDTCounter(IHeadDistanceTravelledController controller)
        {
            this._controller = controller;
        }
        public override void CounterInit()
        {
            this._controller.OnDistanceChanged += this.OnDistanceChanged;
            string defaultValue = FormatCutSpeed(0);
            if (PluginConfig.Instance.EnableLabel)
            {
                var label = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(x, y, z));
                label.text = "Head Distance Travelled";
                label.fontSize = PluginConfig.Instance.LabelFontSize;
            }
            Vector3 leftOffset = new Vector3(x, y - 0.2f, z);
            TextAlignmentOptions leftAlign = TextAlignmentOptions.Top;
            _counterHDT = CanvasUtility.CreateTextFromSettings(Settings, leftOffset);
            _counterHDT.lineSpacing = -26;
            _counterHDT.fontSize = PluginConfig.Instance.FigureFontSize;
            _counterHDT.text = defaultValue;
            _counterHDT.alignment = leftAlign;
        }
        public override void CounterDestroy()
        {
            this._controller.OnDistanceChanged -= this.OnDistanceChanged;
        }
        private void OnDistanceChanged(float distance, in Vector3 hmdPosition, in Quaternion hmdRotation)
        {
            _counterHDT.text = FormatCutSpeed(distance);
        }

        private string FormatCutSpeed(double distance)
        {
            return $"{distance.ToString($"F{PluginConfig.Instance.DecimalPrecision}", CultureInfo.InvariantCulture)}m";
        }
    }
}
