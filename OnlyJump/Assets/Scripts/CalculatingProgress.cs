using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatingProgress : MonoBehaviour
{
    private Slider progressSlider;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private PlayerController player;

    private float startPointPositionx;
    
    private void Start()
    {
        progressSlider = GetComponent<Slider>();
        GameManager.Instance.OnStatsUpdated += GameManager_OnStatsUpdated;
        progressSlider.maxValue = CalculateLevelLength();
        startPointPositionx = Mathf.Abs(startPoint.transform.position.x);
    }
    private void OnDestroy() => GameManager.Instance.OnStatsUpdated -= GameManager_OnStatsUpdated;
   
    private void GameManager_OnStatsUpdated(object sender, System.EventArgs e) => GameManager.Instance.CheckLevelProgress((progressSlider.value / progressSlider.maxValue));
   
    private void Update() => progressSlider.value = (Mathf.Abs(player.transform.position.x) - startPointPositionx);
 
    private float CalculateLevelLength() => Mathf.Abs(endPoint.transform.position.x) - Mathf.Abs(startPoint.transform.position.x);
   
}
