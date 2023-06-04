using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OnlyJump.UI
{
    public class StatsWindow : MenuWindow
    {
        [SerializeField] private TextMeshProUGUI totalJumps;
        [SerializeField] private TextMeshProUGUI totalAttempts;
        [SerializeField] private TextMeshProUGUI totalGainCoins;
        [SerializeField] private TextMeshProUGUI bestRecord;

        public override void OpenWindow()
        {
            totalAttempts.SetText($"{GameManager.Instance.TotalAttempt}");
            totalJumps.SetText($"{GameManager.Instance.TotalJumps}");
            totalGainCoins.SetText($"{GameManager.Instance.TotalGainCoins}");
            bestRecord.SetText($"{GameManager.Instance.TheBestRecord}");
        }
    }
}
