using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class optionScript : MonoBehaviour {

    // Use this for initialization
    GameObject menu;
    GameObject engPan;
    GameObject swePan;
	void Start () {
        menu = GameObject.Find("MenuSystem");
        menu.SetActive(false);
        swePan = GameObject.Find("swePan");
        engPan = GameObject.Find("engPan");
        engPan.SetActive(false);

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
                }

                if (clicked.Equals("EnglishButton"))
                {
                    Question.getInstance().setLang("Eng");
                    engPan.SetActive(true);
                    swePan.SetActive(false);
                }
                if (clicked.Equals("CloseMenuSystemButton"))
                {
                    menu.SetActive(false);
                }



            }
        }
    }
}
