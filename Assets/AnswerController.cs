using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//FOR CECHK KEYBOARD KEYDOWN
public class AnswerController : MonoBehaviour
{
    public GameController GameController;
    public QuestionController QuestionController;

    public Button A, S, D, J, K, L;

    Color correctColor;
    Color incorrectColor;

    public void P1_Check_Answer(int enterAns)
    {
        Debug.Log("enterAns = " + enterAns);
        //correct
        if (QuestionController.P1_currentTargetAns == enterAns)
        {
            //targetplayer++
            GameController.P1_AddScore();
            //PLAYSOUND
            StartCoroutine(OnAnswerFeedback(enterAns, Color.green, new Button[]{A,S,D}));
        }
        //Incorrect
        else
        {
            GameController.P1AnsCombo = 0;
            //incorrect fx
            //show correct Ans animation
            //correct ans pos
            StartCoroutine(OnAnswerFeedback(enterAns, Color.red, new Button[]{A,S,D}));
        }

        //check game stati(time)
        //next q
        QuestionController.Generate_Question(true);
    }

    IEnumerator OnAnswerFeedback(int enterAns, Color color, Button[] buttonGroup) {
        Button targetButton = buttonGroup[enterAns];

        if (targetButton) {
            targetButton.image.color = color;
        }
        yield return new WaitForSeconds(2);
        if (targetButton) {
            targetButton.image.color = Color.white;
        }
    }

    public void P2_Check_Answer(int enterAns)
    {
        Debug.Log("enterAns = " + enterAns);
        //correct
        if (QuestionController.P2_currentTargetAns == enterAns)
        {
            //targetplayer++
            GameController.P2_AddScore();
            //PLAYSOUND
            StartCoroutine(OnAnswerFeedback(enterAns, Color.green, new Button[]{J,K,L}));
        }
        //Incorrect
        else
        {
            GameController.P2AnsCombo = 0;
            //incorrect fx
            //show correct Ans animation
            //correct ans pos
            StartCoroutine(OnAnswerFeedback(enterAns, Color.red, new Button[]{J,K,L}));
        }

        //check game stati(time)
        //next q
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
            Debug.Log("A");

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Check Ans
            P1_Check_Answer(1);
            Debug.Log("S");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Check Ans
            P1_Check_Answer(2);
            Debug.Log("D");
        }
        //P2 Control
        if (Input.GetKeyDown(KeyCode.J))
        {
            //Check Ans
            P2_Check_Answer(0);
            Debug.Log("J");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Check Ans
            P2_Check_Answer(1);
            Debug.Log("K");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Check Ans
            P2_Check_Answer(2);
            Debug.Log("L");
        }

    }
}
