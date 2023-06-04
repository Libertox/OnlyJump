using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace OnlyJump.UI
{
    public class ShopWindow : MenuWindow
    {
        [SerializeField] private Image playerSkin;
        [SerializeField] private TextMeshProUGUI quantityOfCoin;
        [SerializeField] private TextMeshProUGUI costOfSkin;
        [SerializeField] private GameObject costText;
        [SerializeField] private GameObject buyButton;
        [SerializeField] private GameObject skinAvailable;

        private ColorSelectionButton selectionButton;

        public override void OpenWindow() => quantityOfCoin.SetText($"{GameManager.Instance.Pocket} <sprite=0>");
        
        public void SelectButton(ColorSelectionButton colorbutton)
        {
            selectionButton = colorbutton;
            AudioManager.Instance.PlayButtonSound();
            playerSkin.color = selectionButton.GetSkinColor();
            CheckSkinAvailable();
        }

        private void CheckSkinAvailable()
        {
            if (GameManager.Instance.GetAvailableSkinsList().Contains(selectionButton.GetSkinColor()))
            {
                costText.SetActive(false);
                buyButton.SetActive(false);
                skinAvailable.SetActive(true);
                GameManager.Instance.PlayerColor = selectionButton.GetSkinColor();
            }
            else
            {
                skinAvailable.SetActive(false);
                costOfSkin.SetText($"{selectionButton.GetSkinCost()}");
                costOfSkin.color = (GameManager.Instance.Pocket >= selectionButton.GetSkinCost()) ? Color.green : Color.red;
                costText.SetActive(true);
                buyButton.SetActive(true);
            }
        }

        public void BuySkin()
        {
            if (selectionButton.GetSkinCost() <= GameManager.Instance.Pocket)
            {
                AudioManager.Instance.PlayBuySound();
                GameManager.Instance.BuySkin(selectionButton);
                costText.SetActive(false);
                buyButton.SetActive(false);
                skinAvailable.SetActive(true);
                quantityOfCoin.SetText($"{GameManager.Instance.Pocket} <sprite=0> ");
            }
            else
                AudioManager.Instance.PlayButtonSound();
        }
    }
}
