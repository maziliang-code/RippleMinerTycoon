using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Custodian
{
    public class UI_CustodianPanel
    {

        #region ui component
        [SerializeField] private Button Btn_Money;
        public Button Money { get => Btn_Money; }
        [SerializeField] private Image Img_SelectMoney;
        public Image SelectMoney { get => Img_SelectMoney; }
        [SerializeField] private Image Img_MoneyImage;
        public Image MoneyImage { get => Img_MoneyImage; }
        [SerializeField] private TextMeshProUGUI Text_MoneyText;
        public TextMeshProUGUI MoneyText { get => Text_MoneyText; }
        [SerializeField] private Button Btn_Investors;
        public Button Investors { get => Btn_Investors; }
        [SerializeField] private Image Img_SelectInvestors;
        public Image SelectInvestors { get => Img_SelectInvestors; }
        [SerializeField] private Image Img_InvestorImage;
        public Image InvestorImage { get => Img_InvestorImage; }
        [SerializeField] private TextMeshProUGUI Text_InvestorText;
        public TextMeshProUGUI InvestorText { get => Text_InvestorText; }
        [SerializeField] private ScrollRect Scroll_Items;
        public ScrollRect Items { get => Scroll_Items; }
        [SerializeField] private Button Btn_CloseBtn;
        public Button CloseBtn { get => Btn_CloseBtn; }

        public void Reset(BasePanel basePanel)
        {
            Btn_Money = basePanel.transform.Find("Bg/Tables/Btn_Money").GetComponent<Button>();
            Img_SelectMoney = basePanel.transform.Find("Bg/Tables/Btn_Money/Img_SelectMoney").GetComponent<Image>();
            Img_MoneyImage = basePanel.transform.Find("Bg/Tables/Btn_Money/Img_MoneyImage").GetComponent<Image>();
            Text_MoneyText = basePanel.transform.Find("Bg/Tables/Btn_Money/Text_MoneyText").GetComponent<TextMeshProUGUI>();
            Btn_Investors = basePanel.transform.Find("Bg/Tables/Btn_Investors").GetComponent<Button>();
            Img_SelectInvestors = basePanel.transform.Find("Bg/Tables/Btn_Investors/Img_SelectInvestors").GetComponent<Image>();
            Img_InvestorImage = basePanel.transform.Find("Bg/Tables/Btn_Investors/Img_InvestorImage").GetComponent<Image>();
            Text_InvestorText = basePanel.transform.Find("Bg/Tables/Btn_Investors/Text_InvestorText").GetComponent<TextMeshProUGUI>();
            Scroll_Items = basePanel.transform.Find("Bg/Panel/Scroll_Items").GetComponent<ScrollRect>();
            Btn_CloseBtn = basePanel.transform.Find("Bg/Btn_CloseBtn").GetComponent<Button>();
        }

        #endregion

    }

}
