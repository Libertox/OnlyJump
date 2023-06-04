using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.RecordMode
{
    [CreateAssetMenu(fileName = "SpeedMultiplexer", menuName = "RecordMode/SpeedMultiplexer")]
    public class SpeedMultiplexerSO : ScriptableObject
    {
        [SerializeField] private float[] speedBust;
        [SerializeField] private int[] borderChnageSpeed;

        public float GetSpeedBust(float record)
        {
           
            for (int i = 0; i < speedBust.Length - 1; i++)
            {
                if (record > borderChnageSpeed[i] && record < borderChnageSpeed[i + 1])
                    return speedBust[i];
            }
            return speedBust[speedBust.Length - 1];
        }
    }
}
