using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button testingBtn;
    public int gameMode = 0;

    public int P1Score, P2Score;

    void Start()
    {
        GameReset();
    }
    void GameReset()
    {
        P1Score =0;
        P2Score =0;
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

    void GameStart()
    {

    }

    //


    void GameModeChange(int num)
    {
        gameMode = num;
    }



}
