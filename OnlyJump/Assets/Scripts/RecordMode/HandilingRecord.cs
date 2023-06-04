using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OnlyJump.RecordMode
{
    public class HandilingRecord : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentRecordText;
        [SerializeField] private TextMeshPro theBestRecordText;

        public float CurrentRecord { get; private set; }

        private void Start()
        {
            theBestRecordText.SetText($"The Best Record: {GameManager.Instance.TheBestRecord}");
            GameManager.Instance.OnStatsUpdated += GameManager_OnStatsUpdated;
        }
        private void OnDestroy() => GameManager.Instance.OnStatsUpdated -= GameManager_OnStatsUpdated;
       
        private void GameManager_OnStatsUpdated(object sender, System.EventArgs e) => GameManager.Instance.CheckTheBestRecord((int)CurrentRecord);

        private void Update()
        {
            if (LevelManager.Instance.IsPlayState())
            {
                CurrentRecord += Time.deltaTime;
                currentRecordText.SetText($"{(int)CurrentRecord}");
            }
        }
    }
}
