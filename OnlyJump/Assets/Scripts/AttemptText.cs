using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttemptText : MonoBehaviour
{
    [SerializeField] private TextMeshPro attemptText;
    private void Start() => attemptText.SetText($"Attempt: {GameManager.Instance.CurrentAttempt}");
   
}
