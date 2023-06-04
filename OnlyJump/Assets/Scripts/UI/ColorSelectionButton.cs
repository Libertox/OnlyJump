using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnlyJump.UI
{
    public class ColorSelectionButton : MonoBehaviour
    {
        [SerializeField] private Color color;
        [SerializeField] private int skinCost;

        private void Awake() => GetComponent<Image>().color = color;

        public Color GetSkinColor() => color;
        public int GetSkinCost() => skinCost;
    }
}
