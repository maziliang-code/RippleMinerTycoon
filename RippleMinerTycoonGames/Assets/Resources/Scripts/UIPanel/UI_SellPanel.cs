using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SellPanel
{
    public class UI_SellPanel
    {

        #region ui component
        [SerializeField] private Button Btn_CloseBtn;
        public Button CloseBtn { get => Btn_CloseBtn; }
        [SerializeField] private TextMeshProUGUI Text_SaleContent;
        public TextMeshProUGUI SaleContent { get => Text_SaleContent; }
        [SerializeField] private Button Btn_ClaimBtn;
        public Button ClaimBtn { get => Btn_ClaimBtn; }
        [SerializeField] private TextMeshProUGUI Text_Claim;
        public TextMeshProUGUI Claim { get => Text_Claim; }
        [SerializeField] private Button Btn_BuyBtn;
        public Button BuyBtn { get => Btn_BuyBtn; }
        [SerializeField] private TextMeshProUGUI Text_Buy;
        public TextMeshProUGUI Buy { get => Text_Buy; }

        public void Reset(BasePanel basePanel)
        {
            Btn_CloseBtn = basePanel.transform.Find("Bg/Btn_CloseBtn").GetComponent<Button>();
            Text_SaleContent = basePanel.transform.Find("Bg/Panel/Text_SaleContent").GetComponent<TextMeshProUGUI>();
            Btn_ClaimBtn = basePanel.transform.Find("Bg/Panel/Btn_ClaimBtn").GetComponent<Button>();
            Text_Claim = basePanel.transform.Find("Bg/Panel/Btn_ClaimBtn/Text_Claim").GetComponent<TextMeshProUGUI>();
            Btn_BuyBtn = basePanel.transform.Find("Bg/Panel/Btn_BuyBtn").GetComponent<Button>();
            Text_Buy = basePanel.transform.Find("Bg/Panel/Btn_BuyBtn/Text_Buy").GetComponent<TextMeshProUGUI>();
        }

        #endregion


    }

}
