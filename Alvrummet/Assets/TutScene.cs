using System;
using UnityEngine;
using System.Collections;

public class TutScene
{

    GameObject tut1 = GameObject.Find("Tutor1");
    GameObject tut2 = GameObject.Find("Tutor2");
    GameObject tut3 = GameObject.Find("Tutor3");

    ArrayList tutList = new ArrayList();

    private int currentTutorial;

    public bool tutEnd = false;

    public TutScene()
    {
        tutList.Add(tut1);
        tutList.Add(tut2);
        tutList.Add(tut3);

        currentTutorial = 0;

        setAllHide();
        tut1.SetActive(true);
    }



    private void setAllHide()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = tutList[i] as GameObject;
            obj.SetActive(false);
        }
    }


    public void showNextTut(String s)
    {
        setAllHide();

        if (s.Equals("Tutor1") || s.Equals("Tutor2") || s.Equals("Tutor3"))
        {

            if (currentTutorial < 2)
            {
                currentTutorial++;
                GameObject obj = tutList[currentTutorial] as GameObject;
                obj.SetActive(true);
            }
            else if (currentTutorial == 2)
            {
                setAllHide();
                tutEnd = true;
            }
        }

    }


}

