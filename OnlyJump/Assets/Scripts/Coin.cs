using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, Interactable
{
    public static event EventHandler OnRaised;

    public void Interact()
    {
        OnRaised?.Invoke(this, EventArgs.Empty);
        gameObject.SetActive(false);
    }
}
