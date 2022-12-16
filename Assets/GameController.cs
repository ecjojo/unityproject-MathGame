using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button testingBtn;

    public int gameMode = 0;


    void Awake()
    {
        testingBtn.onClick.AddListener(Testing);
    }

    void Testing()
    {
        //GEN Q
        Generate_Question();
        //GEN A BTN
        Generate_Answer();
    }

    //
    void Start()
    {

    }
    void Update()
    {

    }

#region Generate Question

    void Generate_Question()
    {

    }
    void Generate_Answer()
    {

    }

#endregion

    public void Check_Answer()
    {
        //correct

        //Incorrect
    }


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

    void GameMode_Addition()
    {
        //2+2 = ?
    }
    void GameMode_Subtraction()
    {
        //2-2 = ?  
    }

    void GameMode_MoreandLess()
    {
        //2(> or = or <)3 
    }

    void GameMode_Mix()
    {
        //2-2 (> or = or <)3+3
    }


}
