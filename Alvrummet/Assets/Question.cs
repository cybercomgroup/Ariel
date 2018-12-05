using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question{
    ArrayList questions = new ArrayList();
    int currQuestion = 0;
    int noQ;

    public Question(){
        loadQuestions();

        noQ = questions.Count;
    }

    public int getCurr(){
        return currQuestion;
    }

    public string GetQ(){
        string l = questions[currQuestion] as string;

        return l.Split('@')[0];
    }

    public string GetA(){
        string l = questions[currQuestion] as string;

        return l.Split('@')[1];
    }

    public void loadQuestions(){
        TextAsset txtAsset = (TextAsset)Resources.Load("q");
        string s = txtAsset.text;



        foreach (string r in s.Split('\n'))
        {
            if (!r.Equals("/END"))
            {
                questions.Add(r);
            }
        }

    }


    public bool nextQuestion(){
        if (currQuestion < questions.Count - 1)
        {
            currQuestion++;
            return true;
        }
        else{
            return false;
        }
    }

    public int getNoQ(){
        return noQ;
    }

    public void Reset(){
        currQuestion = 0;

    }
      
}