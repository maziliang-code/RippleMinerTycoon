using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    public class Item_MineralItem
    {
        #region ui component
        [SerializeField] private Image Img_ItemIcon;
        public Image ItemIcon { get => Img_ItemIcon; }
        [SerializeField] private TextMeshProUGUI Text_LvText;
        public TextMeshProUGUI LvText { get => Text_LvText; }
        [SerializeField] private Button Btn_LvUpBtn;
        public Button LvUpBtn { get => Btn_LvUpBtn; }
        [SerializeField] private TextMeshProUGUI Text_LvUpText;
        public TextMeshProUGUI LvUpText { get => Text_LvUpText; }
        [SerializeField] private TextMeshProUGUI Text_MultipleText;
        public TextMeshProUGUI MultipleText { get => Text_MultipleText; }

        public void Reset(BasePanel basePanel)
        {
            Img_ItemIcon = basePanel.transform.Find("ItemBg/Img_ItemIcon").GetComponent<Image>();
            Text_LvText = basePanel.transform.Find("ItemBg/Text_LvText").GetComponent<TextMeshProUGUI>();
            Btn_LvUpBtn = basePanel.transform.Find("Btn_LvUpBtn").GetComponent<Button>();
            Text_LvUpText = basePanel.transform.Find("Btn_LvUpBtn/Text_LvUpText").GetComponent<TextMeshProUGUI>();
            Text_MultipleText = basePanel.transform.Find("Btn_LvUpBtn/Text_MultipleText").GetComponent<TextMeshProUGUI>();
        }

        #endregion
    }

}
