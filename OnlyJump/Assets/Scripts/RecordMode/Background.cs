using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.RecordMode
{
    public class Background : MonoBehaviour
    {
        private Vector3 startPos;
        private float repeatWidth;

        [SerializeField] private HandilingRecord recordHandler;
        [SerializeField] private BackgroundSpriteSO backgroundSprite;

        [SerializeField] private SpriteRenderer groundSpriteRender;
        [SerializeField] private SpriteRenderer dirtSpriteRenderer;

        private void Start()
        {
            startPos = transform.position;
            repeatWidth = GetComponentInChildren<BoxCollider2D>().size.x / 2;
        }

        private void Update()
        {
            RepeatBackground();
            ChangeBackgroundSprites();
        }

        private void RepeatBackground()
        {
            if (transform.position.x < startPos.x - repeatWidth)
                transform.position = startPos;
        }

        private void ChangeBackgroundSprites()
        {
            groundSpriteRender.sprite = backgroundSprite.GetGroundSprite(recordHandler.CurrentRecord);
            dirtSpriteRenderer.sprite = backgroundSprite.GetDirtSprite(recordHandler.CurrentRecord);
        }
    }
}
