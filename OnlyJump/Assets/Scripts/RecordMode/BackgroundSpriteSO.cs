using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.RecordMode
{
    [CreateAssetMenu(fileName = "BackgroundSprite", menuName = "RecordMode/BackgroundSprite")]
    public class BackgroundSpriteSO : ScriptableObject
    {
        [SerializeField] private Sprite[] groundSprites;
        [SerializeField] private Sprite[] dirtSprites;
        [SerializeField] private int[] biomeBorder;

        public Sprite GetGroundSprite(float record)
        {
            for (int i = 0; i < biomeBorder.Length - 1; i++)
            {
                if (record > biomeBorder[i] && record < biomeBorder[i + 1])
                    return groundSprites[i];
            }
            return groundSprites[groundSprites.Length - 1];
        }

        public Sprite GetDirtSprite(float record)
        {
            for (int i = 0; i < biomeBorder.Length - 1; i++)
            {
                if (record > biomeBorder[i] && record < biomeBorder[i + 1])
                    return dirtSprites[i];
            }
            return dirtSprites[dirtSprites.Length - 1];
        }
    }
}
