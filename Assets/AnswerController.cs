using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//FOR CECHK KEYBOARD KEYDOWN
public class AnswerController : MonoBehaviour
{
    public GameController GameController;
    public QuestionController QuestionController;
    public AudioController AudioController;

    public Button A, S, D, J, K, L;

    Color correctColor;
    Color incorrectColor;

    bool P1_canContinue = true;
    bool P2_canContinue = true;

    public void P1_Check_Answer(int enterAns)
    {

        //correct
        if (P1_canContinue)
        {
            Debug.Log("enterAns = " + enterAns);
            if (QuestionController.P1_currentTargetAns == enterAns)
            {
                //targetplayer++
                GameController.P1_AddScore();
                //PLAYSOUND

                QuestionController.Generate_Question(true);
                AudioController.PlayCorrect();
            }
            //Incorrect
            else
            {
                GameController.P1AnsCombo = 0;
                //incorrect fx
                //show correct Ans animation
                //correct ans pos
                StartCoroutine(OnAnswerFeedback(QuestionController.P1_currentTargetAns, Color.green, new Button[] { A, S, D }));
                StartCoroutine(OnAnswerFeedback(enterAns, Color.red, new Button[] { A, S, D }));
                P1_canContinue = false;
                StartCoroutine(P1_StopAnswerPunishment());
                AudioController.PlayIncorrect();

            }
            //check game stati(time)
            //next q
        }

    }


    public void P2_Check_Answer(int enterAns)
    {
        if (P2_canContinue)
        {
            Debug.Log("enterAns = " + enterAns);
            //correct
            if (QuestionController.P2_currentTargetAns == enterAns)
            {
                //targetplayer++
                GameController.P2_AddScore();
                //PLAYSOUND

                QuestionController.Generate_Question(false);
                AudioController.PlayCorrect();
            }
            //Incorrect
            else
            {
                GameController.P2AnsCombo = 0;
                //incorrect fx
                //show correct Ans animation
                //correct ans pos
                StartCoroutine(OnAnswerFeedback(QuestionController.P2_currentTargetAns, Color.green, new Button[] { J, K, L }));

                StartCoroutine(OnAnswerFeedback(enterAns, Color.red, new Button[] { J, K, L }));
                P2_canContinue = false;
                StartCoroutine(P2_StopAnswerPunishment());
                AudioController.PlayIncorrect();
            }

            //check game stati(time)
            //next q

        }
    }

    IEnumerator OnAnswerFeedback(int enterAns, Color color, Button[] buttonGroup)
    {
        Button targetButton = buttonGroup[enterAns];

        if (targetButton)
        {
            targetButton.image.color = color;
            if (color == Color.red)
            {
                targetButton.transform.DOShakePosition(1, new Vector3(3, 3, 0));
            }
            if (color == Color.green)
            {
                targetButton.transform.DOShakeRotation(0.5f, new Vector3(1, 1, 0));
            }
        }
        yield return new WaitForSeconds(2);
        if (targetButton)
        {
            targetButton.image.color = Color.white;
        }
    }

    IEnumerator P1_StopAnswerPunishment()
    {
        yield return new WaitForSeconds(2);
        P1_canContinue = true;
        QuestionController.Generate_Question(true);
    }

    IEnumerator P2_StopAnswerPunishment()
    {
        yield return new WaitForSeconds(2);
        P2_canContinue = true;
        QuestionController.Generate_Question(false);
    }

    void Awake()
    {
        A.onClick.AddListener(() => { P1_Check_Answer(0); });
        S.onClick.AddListener(() => { P1_Check_Answer(1); });
        D.onClick.AddListener(() => { P1_Check_Answer(2); });

        J.onClick.AddListener(() => { P2_Check_Answer(0); });
        K.onClick.AddListener(() => { P2_Check_Answer(1); });
        L.onClick.AddListener(() => { P2_Check_Answer(2); });
    }

    void Update()
    {

        //P1 Control
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Check Ans
            P1_Check_Answer(0);
            //Debug.Log("A");

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Check Ans
            P1_Check_Answer(1);
            //Debug.Log("S");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Check Ans
            P1_Check_Answer(2);
            //Debug.Log("D");
        }


        //P2 Control
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Check Ans
            P2_Check_Answer(0);
            //Debug.Log("J");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Check Ans
            P2_Check_Answer(1);
            //Debug.Log("K");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Check Ans
            P2_Check_Answer(2);
            //Debug.Log("L");
        }

    }
}
