using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Show All button function
//Answer System
public class ClickableButtonController : MonoBehaviour
{
    public QuestionController QuestionController;
    public GameController GameController;
    public PanelController PanelController;

    [Header("Button Objects")]
    //MEUN
    public Button startBtn;
    //GAME & RESULT
    public Button backBtn;
    public Button replayBtn;

    public Button exitBtn;
    public Button challngeBtn;


    private void Awake()
    {
        startBtn.onClick.AddListener(GameStartOnclick);
        backBtn.onClick.AddListener(BackToMeunOnclick);
        replayBtn.onClick.AddListener(BackToMeunOnclick);
        exitBtn.onClick.AddListener(BackToMeunOnclick);
        challngeBtn.onClick.AddListener(BackToMeunOnclick);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void ChallengeModeStart()
    {
        QuestionController.isCazryMode = true;

        PanelController.SetCurrentPanel(1);
        GameController.isCountdownStarted = true;
        GameController.ReGenerate_Question();
    }

    void GameStartOnclick()
    {
        //PanelController
        QuestionController.isCazryMode = false;

        PanelController.SetCurrentPanel(1);
        GameController.isCountdownStarted = true;
        GameController.ReGenerate_Question();
    }

    void BackToMeunOnclick()
    {
        //PanelController
        PanelController.SetCurrentPanel(0);
        GameController.GameReset();
    }

}

