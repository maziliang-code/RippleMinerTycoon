using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private void Awake()
    {
        DispositionManager.Instance.Init();
    }
    void Start ()
    {
        MineManager.Instance.Init();
        UIManager.Instance.PushPanel(UIPanelType.UI_MainPanel);
        
	}
}
