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
    public int gameMode = 1;

    [Header("Countdown")]
    public bool isCountdownStarted = false;
    float CountdownSystem = 4;
    public TMP_Text CountdownDisplay;
    int gameStartedCountDown;

    [Header("Timer")]
    public bool isGameStartded = false;
    float timeRemainingSystem = 90;
    public TMP_Text TimerDisplay;
    int gameTimeCounter;

    public QuestionController QuestionController;

    [Header("Score System")]

    public Slider ScoreBar;
    public float P1Score, P2Score;

    public int P1AnsCombo, P2AnsCombo;

    public TMP_Text P1ScoreDisplay, P2ScoreDisplay;

    float P1AnsSpeed, P2AnsSpeed;

    [Header("Result")]
    public TMP_Text ResultDisplay;


    public void P1_AddScore()
    {
        float AnsSpeed = P1AnsSpeed - timeRemainingSystem; //eg.90-87=
        Debug.Log(P1AnsCombo + " : " + AnsSpeed);
        P1AnsSpeed = timeRemainingSystem;

        P1AnsCombo++;
        float comboscore = (1 + P1AnsCombo * 0.1f) * 10;
        P1Score += (int)comboscore;

        ScoreUIupdate();
    }

    public void P2_AddScore()
    {
        float AnsSpeed = gameTimeCounter - P2AnsSpeed;
        //P2AnsSpeed = 

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

    }
    void GameReset()
    {
        P1Score = 0;
        P2Score = 0;
        gameMode = 1;

        P1AnsSpeed = gameTimeCounter;
        P2AnsSpeed = gameTimeCounter;

        CountdownSystem = 4;
        timeRemainingSystem = 90;
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
                CountdownTextupdate();

            }
            else if (CountdownSystem == 0)
            {
                CountdownDisplay.text = "GO!";
            }
            else
            {
                CountdownSystem = 0;
                PanelController.SetCurrentPanel(2);
                isGameStartded = true;
                isCountdownStarted = false;
            }


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
            ResultDisplay.text = "Winner is Player 1";
        }
        else if (P1Score < P2Score)
        {
            //P2 WIN
            ResultDisplay.text = "Winner is Player 2";
        }
        else
        {
            //draw
            ResultDisplay.text = "Draw!";
        }

    }

}
