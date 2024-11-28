using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Develop
{
    public class Item_CustodianItem
    {

        #region ui component
        [SerializeField] private TextMeshProUGUI Text_DevelName;
        public TextMeshProUGUI DevelName { get => Text_DevelName; }
        [SerializeField] private TextMeshProUGUI Text_CurrencyCount;
        public TextMeshProUGUI CurrencyCount { get => Text_CurrencyCount; }
        [SerializeField] private Image Img_CurrencyImage;
        public Image CurrencyImage { get => Img_CurrencyImage; }
        [SerializeField] private Button Btn_BuyBtn;
        public Button BuyBtn { get => Btn_BuyBtn; }
        [SerializeField] private TextMeshProUGUI Text_BuyText;
        public TextMeshProUGUI BuyText { get => Text_BuyText; }

        public void Reset(BasePanel basePanel)
        {
            Text_DevelName = basePanel.transform.Find("Text_DevelName").GetComponent<TextMeshProUGUI>();
            Text_CurrencyCount = basePanel.transform.Find("Text_CurrencyCount").GetComponent<TextMeshProUGUI>();
            Img_CurrencyImage = basePanel.transform.Find("Img_CurrencyImage").GetComponent<Image>();
            Btn_BuyBtn = basePanel.transform.Find("Btn_BuyBtn").GetComponent<Button>();
            Text_BuyText = basePanel.transform.Find("Btn_BuyBtn/Text_BuyText").GetComponent<TextMeshProUGUI>();
        }

        #endregion
    }
}
