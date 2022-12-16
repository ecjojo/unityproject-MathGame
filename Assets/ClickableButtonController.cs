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
    public Button startBtn;
    public Button backBtn;

    private void Awake()
    {
        startBtn.onClick.AddListener(StartGameOnclick);
    }

    private void StartGameOnclick()
    {
        Debug.Log("Button clicked with no parameters");
    }

}

