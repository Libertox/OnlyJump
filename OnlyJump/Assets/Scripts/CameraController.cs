using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private PlayerController player;

    private void Update()
    {
        if (LevelManager.Instance.IsPlayState())
            transform.position =  new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) + cameraOffset;
    }
}
