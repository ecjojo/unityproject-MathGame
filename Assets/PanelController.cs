using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class PanelController : MonoBehaviour
{
    public GameObject MeunPanel;
    public GameObject CountdownPanel;
    public GameObject GamePanel;
    public GameObject ResultPanel;

    GameObject TargetPanel;

    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    List<GameObject> items = new List<GameObject>();

    public float fadeTime = 1f;


    void Start()
    {
        TargetPanel = MeunPanel;
        ResetPanel();
    }
    void ResetPanel()
    {
        MeunPanel.GetComponent<CanvasGroup>().alpha = 1f;
        CountdownPanel.GetComponent<CanvasGroup>().alpha = 0f;
        GamePanel.GetComponent<CanvasGroup>().alpha = 0f;
        ResultPanel.GetComponent<CanvasGroup>().alpha = 0f;
    }

    public void SetCurrentPanel(int panel)
    {
        //Current out
        PanelFadeOut();
        //new in
        SetTargetPanel(panel);
        PanelFadeIn();
    }

    void PanelFadeIn()
    {
        TargetPanel.GetComponent<CanvasGroup>().alpha = 0f;
        TargetPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, -1000f, 0f);
        TargetPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        TargetPanel.GetComponent<CanvasGroup>().DOFade(1, fadeTime);
        //StartCoroutine("ItemAnimation");
    }

    void PanelFadeOut()
    {
        TargetPanel.GetComponent<CanvasGroup>().alpha = 1f;
        TargetPanel.GetComponent<RectTransform>().transform.localPosition = new Vector3(0f, 0f, 0f);
        TargetPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InElastic);
        TargetPanel.GetComponent<CanvasGroup>().DOFade(0, fadeTime);
    }

    void SetTargetPanel(int targetPanelName)
    {
        switch (targetPanelName)
        {
            case 0:
                TargetPanel = MeunPanel;
                break;
            case 1:
                TargetPanel = CountdownPanel;
                break;
            case 2:
                TargetPanel = GamePanel;
                break;
            case 3:
                TargetPanel = ResultPanel;
                break;
        }
        Debug.Log("targetPanel: " + TargetPanel);
    }

    IEnumerator ItemAnimation()
    {
        foreach (var item in items)
        {

            item.transform.localPosition = Vector3.zero;

        }
        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);

        }
    }
}
