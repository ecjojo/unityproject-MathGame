using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

//Timer 
// For Start Game
// For Game Countdown
public class GameController : MonoBehaviour
{
    public PanelController PanelController;
    public AudioController AudioController;
    public Button testingBtn;

    public Slider gameModeSlider;
    public int gameMode = 0;

    [Header("Countdown")]
    public bool isCountdownStarted = false;
    public float CountdownSystem = 3;
    public TMP_Text CountdownDisplay;
    int gameStartedCountDown;

    [Header("Timer")]
    public bool isGameStartded = false;
    public float timeRemainingSystem = 90;
    public TMP_Text TimerDisplay;
    int gameTimeCounter;

    public QuestionController QuestionController;

    [Header("Score System")]

    public Slider ScoreBar;
    public float P1Score, P2Score;
    float P1AnsSpeed, P2AnsSpeed;
    public int P1AnsCombo, P2AnsCombo;

    public TMP_Text P1ScoreDisplay, P2ScoreDisplay;

    [Header("Result")]
    public TMP_Text ResultDisplay;


    public void P1_AddScore()
    {
        float AnsSpeed=gameTimeCounter-P1AnsSpeed;
        P1AnsSpeed=gameTimeCounter;
        
        P1AnsCombo++;
        float comboscore = (1 + P1AnsCombo * 0.1f) * 10;
        P1Score += (int)comboscore;

        ScoreUIupdate();
    }

    public void P2_AddScore()
    {
        float AnsSpeed=gameTimeCounter-P2AnsSpeed;
        P2AnsSpeed=gameTimeCounter;
        
        P2AnsCombo++;
        float comboscore = (1 + P2AnsCombo * 0.1f) * 10;
        P2Score += (int)comboscore;

        ScoreUIupdate();
    }

    void ScoreUIupdate()
    {
        P1ScoreDisplay.text = "" + P1Score;
        P2ScoreDisplay.text = "" + P2Score;

        if (P1Score + P2Score > 0)
        {
            float ratio = P1Score / (P1Score + P2Score);
            ScoreBar.DOValue(ratio, 5, false);
            Debug.Log("ratio:" + ratio);
        }
    }

    void Start()
    {
        GameReset();
        GameStart();
        ScoreUIupdate();
        P1AnsSpeed=gameTimeCounter;
        P2AnsSpeed=gameTimeCounter;
    }
    void GameReset()
    {
        P1Score = 0;
        P2Score = 0;
    }

    public void GameStart()
    {
        //if Clicked Start
        //Count down UI
        //start count 3 sec
        //when finished
        //count 60s for game  
        //gen Q N A
        QuestionController.Generate_Question(true);
        QuestionController.Generate_Question(false);

    }
    //
    void Update()
    {
        //GAME START count down
        if (isCountdownStarted)
        {
            if (CountdownSystem > 0)
            {
                CountdownSystem -= Time.deltaTime;
            }
            else
            {
                CountdownSystem = 0;
                isCountdownStarted = false;
                CountdownDisplay.text = "GO!";
                PanelController.SetCurrentPanel(2);
                isGameStartded = true;
            }
            CountdownTextupdate();
        }


        //game timer 
        if (isGameStartded)
        {
            if (timeRemainingSystem > 0)
            {
                timeRemainingSystem -= Time.deltaTime;
            }
            else
            {
                timeRemainingSystem = 0;
                isGameStartded = false;
                EndGame();
            }
            GameCounterTextupdate();
        }

        //GAME START counter

    }

    void CountdownTextupdate()
    {
        gameStartedCountDown = (int)CountdownSystem;
        CountdownDisplay.text = "" + gameStartedCountDown;

    }


    void GameCounterTextupdate()
    {
        gameTimeCounter = (int)timeRemainingSystem;
        TimerDisplay.text = "" + gameTimeCounter;
    }


    public void ChangeGameMode() //UI 
    {
        gameMode = (int)gameModeSlider.value;
    }

    void EndGame()
    {
        AudioController.PlayResult();
        PanelController.SetCurrentPanel(3);

        CheckWinner();
    }

    void CheckWinner()
    {
        //highest score
        if (P1Score > P2Score)
        {
            //P1 WIN
            ResultDisplay.text="Winner is Player 1";
        }
        else if (P1Score < P2Score)
        {
            //P2 WIN
            ResultDisplay.text="Winner is Player 2";
        }
        else
        {
            //draw
            ResultDisplay.text="Draw!";
        }

    }

}
