using TMPro;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public TextMeshProUGUI texts;
    private void Awake()
    {
        texts.text = "222";
        DispositionManager.Instance.Init();
    }
    void Start ()
    {
        DevelopManager.Instance.Init();
        MineManager.Instance.Init();
        texts.text = "333";
        UIManager.Instance.PushPanel(UIPanelType.UI_MainPanel);
        texts.text = "111";

    }
}
