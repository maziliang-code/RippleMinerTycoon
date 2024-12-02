using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main 
{
    public class UI_MainPanel
    {

        #region ui component
        [SerializeField] private TextMeshProUGUI Text_DiamondCount;
        public TextMeshProUGUI DiamondCount { get => Text_DiamondCount; }
        [SerializeField] private Image Img_BtGoldIcon;
        public Image BtGoldIcon { get => Img_BtGoldIcon; }
        [SerializeField] private TextMeshProUGUI Text_BtGoldCount;
        public TextMeshProUGUI BtGoldCount { get => Text_BtGoldCount; }
        [SerializeField] private Image Img_GoldIcon;
        public Image GoldIcon { get => Img_GoldIcon; }
        [SerializeField] private TextMeshProUGUI Text_GoldCount;
        public TextMeshProUGUI GoldCount { get => Text_GoldCount; }
        [SerializeField] private Image Img_CurrencyIcon;
        public Image CurrencyIcon { get => Img_CurrencyIcon; }
        [SerializeField] private TextMeshProUGUI Text_CurrencyCount;
        public TextMeshProUGUI CurrencyCount { get => Text_CurrencyCount; }
        [SerializeField] private Button Btn_MultipleBtn;
        public Button MultipleBtn { get => Btn_MultipleBtn; }
        [SerializeField] private TextMeshProUGUI Text_MultipleCount;
        public TextMeshProUGUI MultipleCount { get => Text_MultipleCount; }
        [SerializeField] private ScrollRect Scroll_Items;
        public ScrollRect Items { get => Scroll_Items; }
        [SerializeField] private Button Btn_DevelopPanel;
        public Button DevelopPanel { get => Btn_DevelopPanel; }
        [SerializeField] private Button Btn_CustodianPanel;
        public Button CustodianPanel { get => Btn_CustodianPanel; }
        [SerializeField] private Button Btn_SellPanel;
        public Button SellPanel { get => Btn_SellPanel; }

        public void Reset(BasePanel basePanel)
        {
            Text_DiamondCount = basePanel.transform.Find("Bg/DiamondBg/Text_DiamondCount").GetComponent<TextMeshProUGUI>();
            Img_BtGoldIcon = basePanel.transform.Find("Bg/BtGoldBg/Img_BtGoldIcon").GetComponent<Image>();
            Text_BtGoldCount = basePanel.transform.Find("Bg/BtGoldBg/Text_BtGoldCount").GetComponent<TextMeshProUGUI>();
            Img_GoldIcon = basePanel.transform.Find("Bg/Img_GoldIcon").GetComponent<Image>();
            Text_GoldCount = basePanel.transform.Find("Bg/Text_GoldCount").GetComponent<TextMeshProUGUI>();
            Img_CurrencyIcon = basePanel.transform.Find("Bg/CurrencyBg/Img_CurrencyIcon").GetComponent<Image>();
            Text_CurrencyCount = basePanel.transform.Find("Bg/CurrencyBg/Text_CurrencyCount").GetComponent<TextMeshProUGUI>();
            Btn_MultipleBtn = basePanel.transform.Find("Bg/Btn_MultipleBtn").GetComponent<Button>();
            Text_MultipleCount = basePanel.transform.Find("Bg/Btn_MultipleBtn/Text_MultipleCount").GetComponent<TextMeshProUGUI>();
            Scroll_Items = basePanel.transform.Find("Bg/Scroll_Items").GetComponent<ScrollRect>();
            Btn_DevelopPanel = basePanel.transform.Find("Bg/Panel/Btn_DevelopPanel").GetComponent<Button>();
            Btn_CustodianPanel = basePanel.transform.Find("Bg/Panel/Btn_CustodianPanel").GetComponent<Button>();
            Btn_SellPanel = basePanel.transform.Find("Bg/Panel/Btn_SellPanel").GetComponent<Button>();
        }

        #endregion

    }

}
