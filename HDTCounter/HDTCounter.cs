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
        private TMP_Text _counterBP;
        private readonly IHeadDistanceTravelledController _controller;
        private RelativeScoreAndImmediateRankCounter _relativeScoreAndImmediateRankCounter;
        private float _distance = 0f;
        private float _relativeScore = 1f;

        [Inject]
        public HDTCounter(IHeadDistanceTravelledController controller, RelativeScoreAndImmediateRankCounter relative)
        {
            this._controller = controller;
            this._relativeScoreAndImmediateRankCounter = relative;
        }
        public override void CounterInit()
        {
            this._controller.OnDistanceChanged += this.OnDistanceChanged;
            if (this._relativeScoreAndImmediateRankCounter)
                this._relativeScoreAndImmediateRankCounter.relativeScoreOrImmediateRankDidChangeEvent += this.RelativeScoreAndImmediateRankCounter_relativeScoreOrImmediateRankDidChangeEvent;
            if (PluginConfig.Instance.EnableLabel)
            {
                var label = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(x, y, z));
                if (PluginConfig.Instance.EnableBp && this._relativeScoreAndImmediateRankCounter)
                    label.text = $"{PluginConfig.Instance.LabelText} (x{PluginConfig.Instance.BpFactor.ToString("F0", CultureInfo.InvariantCulture)} {PluginConfig.Instance.BpFailureThreshold.ToString("F1", CultureInfo.InvariantCulture)}m)";
                else
                    label.text = PluginConfig.Instance.LabelText;
                label.fontSize = PluginConfig.Instance.LabelFontSize;
            }
            _counterHDT = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(x, y - 0.2f, z));
            _counterHDT.lineSpacing = -26;
            _counterHDT.fontSize = PluginConfig.Instance.FigureFontSize;
            _counterHDT.text = FormatHDT(0);
            _counterHDT.alignment = TextAlignmentOptions.Top;
            if (PluginConfig.Instance.EnableBp && this._relativeScoreAndImmediateRankCounter)
            {
                _counterBP = CanvasUtility.CreateTextFromSettings(Settings, new Vector3(x, y - 0.6f, z));
                _counterBP.lineSpacing = -26;
                _counterBP.fontSize = PluginConfig.Instance.FigureFontSize;
                _counterBP.text = FormatBP(100);
                _counterBP.color = Color.cyan;
                _counterBP.alignment = TextAlignmentOptions.Top;
            }
        }
        public override void CounterDestroy()
        {
            this._controller.OnDistanceChanged -= this.OnDistanceChanged;
            if (this._relativeScoreAndImmediateRankCounter)
                this._relativeScoreAndImmediateRankCounter.relativeScoreOrImmediateRankDidChangeEvent -= this.RelativeScoreAndImmediateRankCounter_relativeScoreOrImmediateRankDidChangeEvent;
        }
        private void OnDistanceChanged(float distance, in Vector3 hmdPosition, in Quaternion hmdRotation)
        {
            _distance = distance;
            _counterHDT.text = FormatHDT(distance);
            BpUpdate();
        }

        private void RelativeScoreAndImmediateRankCounter_relativeScoreOrImmediateRankDidChangeEvent()
        {
            _relativeScore = this._relativeScoreAndImmediateRankCounter.relativeScore;
            BpUpdate();
        }

        private string FormatHDT(float distance)
        {
            return $"{distance.ToString($"F{PluginConfig.Instance.DecimalPrecision}", CultureInfo.InvariantCulture)}m";
        }

        private string FormatBP(float distance)
        {
            return $"{distance.ToString($"F{PluginConfig.Instance.BpDecimalPrecision}", CultureInfo.InvariantCulture)}bp";
        }

        private void BpUpdate()
        {
            if (!this._relativeScoreAndImmediateRankCounter)
                return;
            var bp = (_relativeScore * 100f) - (_distance * PluginConfig.Instance.BpFactor);
            var failed = false;
            if (PluginConfig.Instance.BpFailureThreshold > 0)
                failed = _distance >= PluginConfig.Instance.BpFailureThreshold;
            if (failed)
            {
                bp /= 2f;
                _counterBP.color = new Color(1f, 0.27f, 0);
            }
            if (bp < 0)
                bp = 0;
            _counterBP.text = FormatBP(bp);
        }
    }
}
