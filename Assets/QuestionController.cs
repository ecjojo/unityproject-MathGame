using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public bool isCazryMode;
    [Header("Player1")]
    public TMP_Text P1_questionBar;
    public TMP_Text P1_answerBar_A, P1_answerBar_B, P1_answerBar_C;
    public int P1_currentTargetAns = 0; //0-2 

    public int P1_questionCount; 


    [Header("Player2")]
    public TMP_Text P2_questionBar;
    public TMP_Text P2_answerBar_A, P2_answerBar_B, P2_answerBar_C;

    public int P2_currentTargetAns = 0; //0-2

    public int P2_questionCount; 


    [Header("Question Control")]

    public GameController GameController;

    string QuestionText;
    List<string> AnswerText = new List<string>();
    int ansPos = 0;
    //public bool isMixMode;
    void Awake()
    {
        AnswerText.Add("A");
        AnswerText.Add("B");
        AnswerText.Add("C");
        //isCazryMode = false;
        ResetCounter();
    }

    //Generate Question
    #region Generate Question

    void ResetCounter()
    {
        P1_questionCount = 0;
        P2_questionCount = 0;
    }
    void QuestionType()
    {
        int mode = GameController.gameMode;
        if (isCazryMode)
        {
            mode = Random.Range(0, 3);
        }

        switch (mode)
        {
            case 0:
                QuestionText = Question_MoreandLess();
                //Debug.Log("Type 1");
                break;
            case 1:
                QuestionText = Question_Addition();
                //Debug.Log("Type 2");
                break;
            case 2:
                QuestionText = Question_Subtraction();
                //Debug.Log("Type 3");
                break;
            case 3:
                QuestionText = Question_Mix();
                break;
        }
        return;

    }
    public void Generate_Question(bool isP1)
    {

        QuestionType();


        //GET POS (1/2)
        //GET CURRENT Question TYPE
        //DISPLAY TEXT
        //SAVE QuestionANS

        //Generate_Answer()
        //GET POS (1/2)
        //RIGHT Ans
        //RANDOM Ans POS (0,2)
        //RANDOM ANS
        //SEND TO POS
        if (isP1)
        {
            P1_currentTargetAns = ansPos;

            P1_questionBar.text = QuestionText;
            P1_answerBar_A.text = AnswerText[0];
            P1_answerBar_B.text = AnswerText[1];
            P1_answerBar_C.text = AnswerText[2];

            P1_questionCount++;
        }
        else
        {
            P2_currentTargetAns = ansPos;

            P2_questionBar.text = QuestionText;
            P2_answerBar_A.text = AnswerText[0];
            P2_answerBar_B.text = AnswerText[1];
            P2_answerBar_C.text = AnswerText[2];
            
            P2_questionCount++;
        }
    }

    int RandomNum()
    {
        return Random.Range(1, 9);
    }

    #endregion

    int RandomAnsPos()
    {
        return Random.Range(0, 2);
    }

    string Question_MoreandLess()
    {
        AnswerText[0] = " < ";
        AnswerText[1] = " = ";
        AnswerText[2] = " > ";
        //2(> or = or <)3 
        //output text
        int questioSlot_partA = RandomNum();
        int questioSlot_partB = RandomNum();

        if (questioSlot_partA < questioSlot_partB)
        {
            ansPos = 0;
        }
        else if (questioSlot_partA > questioSlot_partB)
        {
            ansPos = 2;
        }
        else
        {
            ansPos = 1;
        }

        return questioSlot_partA + " ? " + questioSlot_partB;
    }

    string Question_Addition()
    {
        //2+2 = ?
        //p1 or p2 
        //output text
        int questioSlot_partA = RandomNum();
        int questioSlot_partB = RandomNum();

        int ansSlot = questioSlot_partA + questioSlot_partB;
        //Debug.Log(ansSlot + "=" + questioSlot_partA + " + " + questioSlot_partB);
        ansPos = RandomAnsPos();
        AnswerText[ansPos] = "" + ansSlot;
        //Random ans
        for (int i = 0; i <= 2; i = i + 0)
        {
            int otherAns = RandomNum();

            if (
            otherAns.ToString() != ansSlot.ToString() &&
            otherAns.ToString() != AnswerText[0] &&
            otherAns.ToString() != AnswerText[1] &&
            otherAns.ToString() != AnswerText[2])
            {
                AnswerText[i] = "" + otherAns;
                i++;
            }
        }
        AnswerText[ansPos] = "" + ansSlot;

        return questioSlot_partA + " + " + questioSlot_partB + " = ?";
    }
    string Question_Subtraction()
    {
        //2-2 = ?  
        //output text
        int questioSlot_partA = RandomNum() + 1;
        int questioSlot_partB = RandomNum();

        while (questioSlot_partB > questioSlot_partA)
        {
            questioSlot_partB = RandomNum();
        }
        int ansSlot = questioSlot_partA - questioSlot_partB;

        for (int i = 0; i <= 2; i = i + 0)
        {

            int otherAns = RandomNum();

            if (
            otherAns.ToString() != ansSlot.ToString() &&
            otherAns.ToString() != AnswerText[0] &&
            otherAns.ToString() != AnswerText[1] &&
            otherAns.ToString() != AnswerText[2])
            {
                AnswerText[i] = "" + otherAns;
                i++;
            }
        }
        ansPos = RandomAnsPos();
        AnswerText[ansPos] = "" + ansSlot;

        //Random ans

        return questioSlot_partA + " - " + questioSlot_partB + " = ?";
    }

    string Question_Mix() //If have time to made
    {
        //2-2 (> or = or <)3+3
        //output text
        int questioSlot_partA1 = RandomNum();
        int questioSlot_partA2 = RandomNum();
        int questioSlot_partB1 = RandomNum();
        int questioSlot_partB2 = RandomNum();

        bool SlotA = RandomSymbol();
        bool SlotB = RandomSymbol();

        return questioSlot_partA1 + "+" + questioSlot_partA2 + "?" + questioSlot_partB1 + "+" + questioSlot_partB2;
    }
    bool RandomSymbol()
    {
        int num = Random.Range(1, 9);
        if (num > 5)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
