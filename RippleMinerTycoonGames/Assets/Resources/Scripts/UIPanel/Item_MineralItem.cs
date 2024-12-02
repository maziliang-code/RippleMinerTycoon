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
        [SerializeField] private Button Btn_Item;
        public Button Item { get => Btn_Item; }
        [SerializeField] private Image Img_ItemIcon;
        public Image ItemIcon { get => Img_ItemIcon; }
        [SerializeField] private TextMeshProUGUI Text_LvText;
        public TextMeshProUGUI LvText { get => Text_LvText; }
        [SerializeField] private Image Img_FillBg;
        public Image FillBg { get => Img_FillBg; }
        [SerializeField] private Image Img_FillIcon;
        public Image FillIcon { get => Img_FillIcon; }
        [SerializeField] private TextMeshProUGUI Text_FillText;
        public TextMeshProUGUI FillText { get => Text_FillText; }
        [SerializeField] private TextMeshProUGUI Text_CdText;
        public TextMeshProUGUI CdText { get => Text_CdText; }
        [SerializeField] private Button Btn_LvUpBtn;
        public Button LvUpBtn { get => Btn_LvUpBtn; }
        [SerializeField] private TextMeshProUGUI Text_LvUpText;
        public TextMeshProUGUI LvUpText { get => Text_LvUpText; }
        [SerializeField] private TextMeshProUGUI Text_MultipleText;
        public TextMeshProUGUI MultipleText { get => Text_MultipleText; }
        [SerializeField] private Image Img_LvUpUnlock;
        public Image LvUpUnlock { get => Img_LvUpUnlock; }
        [SerializeField] private Button Btn_Unlock;
        public Button Unlock { get => Btn_Unlock; }
        [SerializeField] private TextMeshProUGUI Text_UnlockText;
        public TextMeshProUGUI UnlockText { get => Text_UnlockText; }
        [SerializeField] private TextMeshProUGUI Text_UnlockCount;
        public TextMeshProUGUI UnlockCount { get => Text_UnlockCount; }

        public void Reset(BasePanel basePanel)
        {
            Btn_Item = basePanel.transform.Find("Btn_Item").GetComponent<Button>();
            Img_ItemIcon = basePanel.transform.Find("Btn_Item/Img_ItemIcon").GetComponent<Image>();
            Text_LvText = basePanel.transform.Find("Btn_Item/Text_LvText").GetComponent<TextMeshProUGUI>();
            Img_FillBg = basePanel.transform.Find("Img_FillBg").GetComponent<Image>();
            Img_FillIcon = basePanel.transform.Find("Img_FillBg/Img_FillIcon").GetComponent<Image>();
            Text_FillText = basePanel.transform.Find("Img_FillBg/Text_FillText").GetComponent<TextMeshProUGUI>();
            Text_CdText = basePanel.transform.Find("Img_FillBg/Text_CdText").GetComponent<TextMeshProUGUI>();
            Btn_LvUpBtn = basePanel.transform.Find("Btn_LvUpBtn").GetComponent<Button>();
            Text_LvUpText = basePanel.transform.Find("Btn_LvUpBtn/Text_LvUpText").GetComponent<TextMeshProUGUI>();
            Text_MultipleText = basePanel.transform.Find("Btn_LvUpBtn/Text_MultipleText").GetComponent<TextMeshProUGUI>();
            Img_LvUpUnlock = basePanel.transform.Find("Btn_LvUpBtn/Img_LvUpUnlock").GetComponent<Image>();
            Btn_Unlock = basePanel.transform.Find("Btn_Unlock").GetComponent<Button>();
            Text_UnlockText = basePanel.transform.Find("Btn_Unlock/Text_UnlockText").GetComponent<TextMeshProUGUI>();
            Text_UnlockCount = basePanel.transform.Find("Btn_Unlock/Text_UnlockCount").GetComponent<TextMeshProUGUI>();
        }

        #endregion

    }

}
