using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class optionScript : MonoBehaviour {

    // Use this for initialization
    GameObject menu;
    GameObject engPan;
    GameObject swePan;
    GameObject tutText;
	void Start () {
        menu = GameObject.Find("MenuSystem");

        tutText = menu.transform.Find("RunTutorialButton").transform.Find("runtutorialText").gameObject;
        swePan = menu.transform.Find("SwedishButton").transform.Find("swePan").gameObject;
        engPan = menu.transform.Find("EnglishButton").transform.Find("engPan").gameObject;
        engPan.SetActive(false);
        swePan.SetActive(true);
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                string clicked = EventSystem.current.currentSelectedGameObject.name;

                if (clicked.Equals("OptionButton"))
                {
                    menu.SetActive(true);
                    
                }

                if(clicked.Equals("SwedishButton"))
                {
                    Question.getInstance().setLang("Swe");
                    engPan.SetActive(false);
                    swePan.SetActive(true);
                    tutText.GetComponent<Text>().text = "Kör tutorial";
                }

                if (clicked.Equals("EnglishButton"))
                {
                    Question.getInstance().setLang("Eng");
                    engPan.SetActive(true);
                    swePan.SetActive(false);
                    tutText.GetComponent<Text>().text = "Run tutorial";
                }
                if (clicked.Equals("CloseMenuSystemButton"))
                {
                    menu.SetActive(false);
                }



            }
        }
    }
}
