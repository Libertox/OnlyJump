using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField] private float effectLength;

    private void Update() => Destroy(gameObject, effectLength);
}
