using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingLine : MonoBehaviour, Interactable
{
    [SerializeField] private Animator victoryTextAnim;
    [SerializeField] private Animator continueButtonAnim;

    public void Interact()
    {
        victoryTextAnim.enabled = true;
        continueButtonAnim.enabled = true;

        GameManager.Instance.CompleteLevel();
    }
}

