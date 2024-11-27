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
        [SerializeField] private TextMeshProUGUI Text_BtCount;
        public TextMeshProUGUI BtCount { get => Text_BtCount; }
        [SerializeField] private TextMeshProUGUI Text_DiamondCount;
        public TextMeshProUGUI DiamondCount { get => Text_DiamondCount; }
        [SerializeField] private TextMeshProUGUI Text_GoldCount;
        public TextMeshProUGUI GoldCount { get => Text_GoldCount; }
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
            Text_BtCount = basePanel.transform.Find("Bg/BtBg/Text_BtCount").GetComponent<TextMeshProUGUI>();
            Text_DiamondCount = basePanel.transform.Find("Bg/DiamondIcon/Text_DiamondCount").GetComponent<TextMeshProUGUI>();
            Text_GoldCount = basePanel.transform.Find("Bg/GoldIcon/Text_GoldCount").GetComponent<TextMeshProUGUI>();
            Text_CurrencyCount = basePanel.transform.Find("Bg/CurrencyIcon/Text_CurrencyCount").GetComponent<TextMeshProUGUI>();
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
