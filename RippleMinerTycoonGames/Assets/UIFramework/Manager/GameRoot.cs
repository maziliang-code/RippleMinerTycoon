using TMPro;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        DispositionManager.Instance.Init();
    }
    void Start ()
    {
        ComputeStringFloat.DividResaultPrecision = 3;
        CustodianManager.Instance.Init();
        AdministratorManager.Instance.Init();
        DevelopManager.Instance.Init();
        MineManager.Instance.Init();
        UIManager.Instance.PushPanel(UIPanelType.UI_MainPanel);
    }
}
