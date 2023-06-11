using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionPlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private GameObject moveEffect;
    [SerializeField] private SpriteRenderer skin;
    [SerializeField] private float deadTime = 1.5f;
    [SerializeField] private LayerMask obstalceLayerMask;
    private Vector2 size;
    private Collider2D colid;

    private void Start()
    {
        size = new Vector2(transform.localScale.x, transform.localScale.y);
        skin.color = GameManager.Instance.PlayerColor;
    }

    private void Update()
    {
        if (LevelManager.Instance.IsPlayState())
        {
            colid = Physics2D.OverlapBox(transform.position, size, 0, obstalceLayerMask);
            if (colid)
                StartCoroutine(DestroyPlayer());

            colid = Physics2D.OverlapBox(transform.position, size, 0);
            if(colid)
            {
                if (colid.TryGetComponent(out Interactable interactable))
                    interactable.Interact();
            }

        }
    }

    private IEnumerator DestroyPlayer()
    {
        LevelManager.Instance.SetGameState(GameState.GameOver);
        Instantiate(deadEffect, skin.transform.position, deadEffect.transform.rotation);
        skin.gameObject.SetActive(false);
        moveEffect.SetActive(false);
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(deadTime);

        LevelManager.Instance.RepeatLevel();
        
    }
}
