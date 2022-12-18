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


    public void PanelFadeIn(string panel)
    {
        SetTargetPanel(panel);
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine("ItemAnimation");
    }

    public void PanelFadeOut(string panel)
    {
        SetTargetPanel(panel);
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InElastic);
        canvasGroup.DOFade(0, fadeTime);
    }

    void SetTargetPanel(string targetPanelName)
    {
        switch (targetPanelName)
        {
            case "MeunPanel":
                TargetPanel = MeunPanel;
                break;
            case "CountdownPanel":
                TargetPanel = CountdownPanel;
                break;
            case "GamePanel":
                TargetPanel = GamePanel;
                break;
            case "ResultPanel":
                TargetPanel = ResultPanel;
                break;
        }

        canvasGroup = TargetPanel.GetComponent<CanvasGroup>();
        rectTransform = TargetPanel.GetComponent<RectTransform>();
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
