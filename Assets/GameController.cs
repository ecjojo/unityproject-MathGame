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
    [Header("Controller")]
    public PanelController PanelController;
    public AudioController AudioController;
    public QuestionController QuestionController;
    public Slider gameModeSlider;
    public int gameMode = 1;

    [Header("Countdown")]
    public bool isCountdownStarted = false;
    float CountdownSystem = 4;
    public TMP_Text CountdownDisplay;
    int gameStartedCountDown;

    [Header("Timer")]
    public bool isGameStartded = false;
    public float timeRemainingSystem = 90;
    public TMP_Text TimerDisplay;
    int gameTimeCounter;

    [Header("Score System")]

    public Slider ScoreBar;
    public float P1Score, P2Score;
    public int P1AnsCombo, P2AnsCombo;
    public TMP_Text P1ScoreDisplay, P2ScoreDisplay;
    public TMP_Text P1CorrectRatioDisplay, P2CorrectRatioDisplay;
    public TMP_Text P1AnsCounterDisplay, P2AnsCounterDisplay;
    public TMP_Text P1AddedScoreDisplay, P2AddedScoreDisplay;

    public Animator Add1, Add2;
    float P1AnsSpeed, P2AnsSpeed;
    float P1AnsTime, P2AnsTime;
    int P1_correctCount; int P2_correctCount;

    [Header("Result")]
    public TMP_Text ResultDisplay;

    public Color P1Color; public Color P2Color;
    public Color P1Color2; public Color P2Color2;
    public Image PanelColor;
    public Image PanelColor2;

    void ResetCounter()
    {
        P1Score = 0;
        P2Score = 0;
        P1_correctCount = 0;
        P2_correctCount = 0;
        P1AnsCombo = 0;
        P2AnsCombo = 0;
        P1CorrectRatioDisplay.text = "100%";
        P2CorrectRatioDisplay.text = "100%";
    }

    public void P1_AddScore()
    {
        P1_correctCount++;

        float Time = P1AnsTime - timeRemainingSystem; //eg.90-87=3
        float Speed = 1 / Time; // eg.1/3=0.33

        P1AnsSpeed = Speed;

        P1AnsCombo++;
        float comboscore = (1 + P1AnsCombo * P1AnsSpeed) * 10;  // eg.(1+5*0.33)*10=26, eg.(1+5*2)*10=110

        P1Score += (int)comboscore;
        P1AddScoreAnim((int)comboscore);

        P1AnsTime = timeRemainingSystem;
        ScoreUIupdate();
    }

    public void P2_AddScore()
    {
        P2_correctCount++;
        float Time = P2AnsTime - timeRemainingSystem; //eg.90-87=3
        float Speed = 1 / Time;

        P2AnsSpeed = Speed;

        P2AnsCombo++;
        float comboscore = (1 + P2AnsCombo * P2AnsSpeed) * 10;
        //display

        //Debug.Log("P1 Score :" + P2AnsCombo + " ,Speed: " + P2AnsSpeed);
        P2Score += (int)comboscore;
        P2AddScoreAnim((int)comboscore);

        P2AnsTime = timeRemainingSystem;
        ScoreUIupdate();
    }

    void ScoreUIupdate()
    {
        if (isGameStartded)
        {
            if (QuestionController.P1_questionCount > 2)
            {
                float CorrectRatio1 = ((float)P1_correctCount / QuestionController.P1_questionCount) * 100f;
                P1CorrectRatioDisplay.text = (int)CorrectRatio1 + "%";
            }
            if (QuestionController.P2_questionCount > 2)
            {
                float CorrectRatio2 = ((float)P2_correctCount / QuestionController.P2_questionCount) * 100f;
                P2CorrectRatioDisplay.text = (int)CorrectRatio2 + "%";
            }
        }

        P1ScoreDisplay.text = "" + P1Score;
        P2ScoreDisplay.text = "" + P2Score;

        //Debug.Log("P1 Score :" + P1_correctCount / QuestionController.P1_questionCount + "  " + QuestionController.P1_questionCount);

        P1AnsCounterDisplay.text = "" + P1_correctCount;
        P2AnsCounterDisplay.text = "" + P2_correctCount;

        if (P1Score + P2Score > 0)
        {
            float ratio = P1Score / (P1Score + P2Score);
            ScoreBar.DOValue(ratio, 5, false);
            //Debug.Log("ratio:" + ratio);
        }
    }
    void P1AddScoreAnim(int num)
    {
        P1AddedScoreDisplay.text = "+" + num;
        Add1.Play("AddScoreFX");
    }
    void P2AddScoreAnim(int num)
    {
        P2AddedScoreDisplay.text = "+" + num;
        Add2.Play("AddScoreFX");
    }

    void Start()
    {
        GameReset();
    }
    public void GameReset()
    {
        //GAME MODE
        gameModeSlider.value = 1;
        gameMode = 1;

        //TIME
        P1AnsSpeed = gameTimeCounter;
        P2AnsSpeed = gameTimeCounter;
        P1AnsTime = 90;
        P2AnsTime = 90;

        CountdownSystem = 4;
        timeRemainingSystem = 90;
        isGameStartded = false;

        ResetCounter();
        ReGenerate_Question();
        ScoreUIupdate();

        //if Clicked Start
        //Count down UI
        //start count 3 sec
        //when finished
        //count 60s for game  
        //gen Q N A
    }


    public void ReGenerate_Question()
    {
        QuestionController.Generate_Question(true);
        QuestionController.Generate_Question(false);
    }

    void Update()
    {
        //GAME START count down
        if (isCountdownStarted)
        {
            if (CountdownSystem > 1)
            {
                //Debug.Log("hi0 " +　CountdownSystem);
                CountdownSystem -= Time.deltaTime;
                CountdownTextupdate();

            }
            else
            {
                //Debug.Log("hi2 " +　CountdownSystem);
                CountdownSystem = 0;
                CountdownDisplay.text = "GO!";

                if (isCountdownStarted)
                {
                    StartCoroutine(OffPanel());
                    StartCoroutine(GameStartPanel());
                }
                isCountdownStarted = false;
            }
            //CountdownTextupdate();

        }

        IEnumerator OffPanel()
        {
            yield return new WaitForSeconds(1f);
            PanelController.SetCurrentPanel(2);
        }

        IEnumerator GameStartPanel()
        {
            yield return new WaitForSeconds(2f);

            isGameStartded = true;
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
        Debug.Log("GameMode Changed!: " + gameMode);
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
            PanelColor.color = P1Color2;
            PanelColor2.color = P1Color;
        }
        else if (P1Score < P2Score)
        {
            //P2 WIN
            ResultDisplay.text = "Winner is Player 2";
            PanelColor.color = P2Color2;
            PanelColor2.color = P2Color;
        }
        else
        {
            //draw
            ResultDisplay.text = "Draw!";
            PanelColor.color = P1Color2;
            PanelColor2.color = P2Color;
        }

    }

}
