using UnityEngine;
using UnityEngine.UI;

public class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if(canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }
    public void Close() 
    {
        UIManager.Instance.PopPanel();
    }
    public virtual void OnEnter()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }
    public virtual void OnPause()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = false;
    }

    public virtual void OnResume()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public virtual void OnExit()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }       
}
