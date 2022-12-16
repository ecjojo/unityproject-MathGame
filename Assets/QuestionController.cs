using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
     [Header("Player1")]
     public TextMeshPro P1_questionBar;
     public TextMeshPro P1_answerBar_A,P1_answerBar_B,P1_answerBar_C;

    [Header("Player2")]
      public TextMeshPro P2_questionBar;
      public TextMeshPro P2_answerBar_A,P2_answerBar_B,P2_answerBar_C;

    //Generate Question
    #region Generate Question

    void Generate_Question()
    {
        //GET POS (1/2)
    }
    void Generate_Answer()
    {
        //GET POS (1/2)
        //RIGHT Ans
        //RANDOM POS (0,2)
        //RANDOM ANS
        //SEND TO POS
    }

    #endregion

/*
    void GameModeChange(int num)
    {
        gameMode = num;

        switch (gameMode)
        {
            case 0:
                GameMode_Addition();
                break;
            case 1:
                GameMode_Subtraction();
                break;
            case 2:
                GameMode_MoreandLess();
                break;
            case 3:
                GameMode_Mix();
                break;
        }
    }
    */

    void GameMode_Addition()
    {
        //2+2 = ?
        //p1 or p2 
        //output text
    }
    void GameMode_Subtraction()
    {
        //2-2 = ?  
        //output text
    }

    void GameMode_MoreandLess()
    {
        //2(> or = or <)3 
        //output text
    }

    void GameMode_Mix()
    {
        //2-2 (> or = or <)3+3
        //output text
    }

}
