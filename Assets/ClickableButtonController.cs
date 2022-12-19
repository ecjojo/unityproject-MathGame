using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Show All button function
//Answer System
public class ClickableButtonController : MonoBehaviour
{
    public GameController GameController;
    public PanelController PanelController;

    [Header("Button Objects")]
    //MEUN
    public Button startBtn;
    //GAME & RESULT
    public Button backBtn;
    public Button replayBtn;


    private void Awake()
    {
        startBtn.onClick.AddListener(GameStartOnclick);
        backBtn.onClick.AddListener(BackToMeunOnclick);
        replayBtn.onClick.AddListener(BackToMeunOnclick);
    }

    private void GameStartOnclick()
    {
        //PanelController
        PanelController.SetCurrentPanel(1);
        GameController.isCountdownStarted=true;
    }

    private void BackToMeunOnclick()
    {
        //PanelController
        PanelController.SetCurrentPanel(0);
    }

}

