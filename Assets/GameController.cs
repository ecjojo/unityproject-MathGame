using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Timer 
// For Start Game
// For Game Countdown
public class GameController : MonoBehaviour
{
    public Button testingBtn;

    public Slider gameModeSlider;
    public int gameMode = 0;

    [Header("Timer")]
    public bool isCountdownStarted = false;
    public float CountdownSystem = 3;
    public bool isGameStartded = false;

    public float timeRemainingSystem = 90;

    public TMP_Text CountdownDisplay;
    public int gameStartedCountDown;

    public TMP_Text TimerDisplay;
    public int gameTimeCounter;

    public QuestionController QuestionController;

    [Header("Score System")]

    public int P1Score, P2Score;
    public int P1AnsSpeed, P2AnsSpeed;
    public int P1AnsCombo, P2AnsCombo;

    public TMP_Text P1ScoreDisplay, P2ScoreDisplay;

    public void P1_AddScore()
    {
        P1Score++;
        P1AnsCombo++;
    }

    public void P2_AddScore()
    {
        P2Score++;
        P2AnsCombo++;
    }

    void ScoreUIupdate()
    {
        P1ScoreDisplay.text = "" + P1Score;
        P2ScoreDisplay.text = "" + P2Score;
    }

    void Start()
    {
        GameReset();
    }
    void GameReset()
    {
        P1Score = 0;
        P2Score = 0;
    }
    void Awake()
    {
        testingBtn.onClick.AddListener(Testing);
    }

    void Testing()
    {
        //GEN Q
        //Generate_Question();
        //GEN A BTN
        //Generate_Answer();
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

    void CheckWinner()
    {
        //highest score
        if (P1Score > P2Score)
        {
            //P1 WIN
        }
        else if (P1Score < P2Score)
        {
            //P2 WIN
        }
        else
        {
            //draw
        }

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
                CountdownDisplay.text = " ";
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
            }
            GameCounterTextupdate();
        }

        //GAME START counter

    }

    void CountdownTextupdate()
    {
        gameStartedCountDown = (int)timeRemainingSystem;
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

}
