using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour {

    // Use this for initialization

    private RaycastHit hit;

    GameMode game;


    bool startTimer = false;
    int timeDone = 0;
    AudioSource audioJa;
    AudioSource audioNej;

    TutScene tut;

    void Start () {
        game = new GameMode();
        tut = new TutScene();

        game.correct.SetActive(false);
        game.wrong.SetActive(false);

        audioJa = GetComponents<AudioSource>()[0];
        audioNej = GetComponents<AudioSource>()[1];
    }
	
	void Update () {
       
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {



            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit)){
                if (tut.tutEnd)
                {
                    game.clickModel(hit.collider.name);
                }
            }


            if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
                if (tut.tutEnd)
                {
                    game.clickGUI(EventSystem.current.currentSelectedGameObject.name);
                }
                else{
                    tut.showNextTut(EventSystem.current.currentSelectedGameObject.name);
                }
            }


        }

        if(game.gameStarted)
            showAns();

    }




    private void showAns(){
        if (game.qState == 1)
        {
            game.correct.SetActive(true);
            audioJa.Play();
            game.qState = 0;
            startTimer = true;

        }
        else if (game.qState == 2)
        {
            game.wrong.SetActive(true);
            audioNej.Play();
            game.qState = 0;
            startTimer = true;
        }

        if (startTimer)
            timeDone++;

        if (timeDone >= 60)
        {
            game.wrong.SetActive(false);
            game.correct.SetActive(false);
            timeDone = 0;
            startTimer = false;
            game.getNextQuestion();
            if (game.gameStarted){
                game.showQuestion();
            }
                
        }


    }
}
