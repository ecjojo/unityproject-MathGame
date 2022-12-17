using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Show All button function
//Answer System
public class ClickableButtonController : MonoBehaviour
{
    public GameController gm;

    [Header("Button Objects")]
    //MEUN
    public Button startBtn;
    //GAME & RESULT
    public Button backBtn;


    private void Awake()
    {
        startBtn.onClick.AddListener(GameStartOnclick);
        backBtn.onClick.AddListener(BackToMeunOnclick);
    }

    private void GameStartOnclick()
    {
        Debug.Log("Button clicked with no parameters");
    }

    private void BackToMeunOnclick()
    {
        Debug.Log("Button clicked with no parameters");
    }

}

