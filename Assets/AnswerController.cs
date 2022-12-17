using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FOR CECHK KEYBOARD KEYDOWN
public class AnswerController : MonoBehaviour
{
    public GameController GameController;
    public QuestionController QuestionController;

    public void P1_Check_Answer(int enterAns)
    {
        //correct
        if (QuestionController.P1_currentTargetAns == enterAns)
        {
            //targetplayer++
            GameController.P1_AddScore();
        }
        //Incorrect
        else
        {
            GameController.P1AnsCombo = 0;
            //incorrect fx
            //show correct Ans animation
            //correct ans pos
        }

        //check game stati(time)
        //next q

    }

    public void P2_Check_Answer(int enterAns)
    {
        //correct
        if (QuestionController.P2_currentTargetAns == enterAns)
        {
            //targetplayer++
            GameController.P2_AddScore();
        }
        //Incorrect
        else
        {
            GameController.P2AnsCombo = 0;
            //incorrect fx
            //show correct Ans animation
            //correct ans pos
        }

        //check game stati(time)
        //next q

    }

    void Update()
    {
        //P1 Control
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Check Ans
            P1_Check_Answer(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Check Ans
            P1_Check_Answer(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Check Ans
            P1_Check_Answer(2);
        }
        //P2 Control
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Check Ans
            P2_Check_Answer(0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Check Ans
            P2_Check_Answer(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Check Ans
            P2_Check_Answer(2);
        }

    }
}
