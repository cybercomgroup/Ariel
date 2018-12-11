using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class GameMode
{
    Question sn = Question.getInstance();

    GameObject questionImg = GameObject.Find("questionIMG");
    GameObject pointsDisp = GameObject.Find("pointsDisplay");
    GameObject startB = GameObject.Find("startButton");
    GameObject sB = GameObject.Find("scoreIMG");
    GameObject exitFrame = GameObject.Find("CompletedGameImage");

    public GameObject correct = GameObject.Find("rightImage");
    public GameObject wrong = GameObject.Find("wrongImage");

    int points = 0;
    public bool gameStarted = false;
    public bool questionAsked = false;

    // 0, ej svar; 1, rätt; 2, fel.
    public int qState = 0;

    public GameMode(){
        sB.SetActive(false);
        pointsDisp.SetActive(false);
        questionImg.SetActive(false);
        exitFrame.SetActive(false);
     }

    public void clickModel(string name)
    {
        if (questionAsked && gameStarted)
        {
            if (name.Equals(sn.GetA()))
            {
                qState = 1;
                points++;
            }
            else
            {
                qState = 2;
            }

            pointsDisp.GetComponent<Text>().text = "Points: " + points + " / " + sn.getNoQ();
            questionAsked = false;
        }

    }

    public void clickGUI(string name){

        if (name.Equals("startButton") && gameStarted == false)
        {
            StartGame();
        }

        if (name.Equals("ExitCompletedGameButton"))
        {
            exitFrame.SetActive(false);
            startB.SetActive(true);
        }
        if (name.Equals("StartNewGameButton") && gameStarted == false){
            exitFrame.SetActive(false);
            StartGame();
        }

        if (name.Equals("questionIMG") || name.Equals("questionText")){
            questionImg.SetActive(false);
            questionAsked = true;
        }

    }



    public void showQuestion(){
        questionImg.SetActive(true);
        questionImg.transform.GetChild(0).GetComponent<Text>().text = sn.GetQ();
        questionImg.transform.GetChild(2).GetComponent<Image>().sprite = Resources.Load(sn.getImg()) as Sprite;
    }

    public void getNextQuestion(){
        if (!sn.nextQuestion())
            gameEnd();
    }

    public void StartGame()
    {
        // Reset all
        points = 0;
        sn.Reset();
        gameStarted = true;


        sB.SetActive(true);
        startB.SetActive(false);
        pointsDisp.SetActive(true);

        pointsDisp.GetComponent<Text>().text = "Points: " + points + " / " + sn.getNoQ();
        showQuestion();
    }

    public void gameEnd()
    {
        exitFrame.SetActive(true);
        exitFrame.transform.GetChild(2).GetComponent<Text>().text = "Points: " + points + " / " + sn.getNoQ();
        sB.SetActive(false);
        gameStarted = false;
    }

  



}