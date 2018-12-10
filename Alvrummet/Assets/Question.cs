using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question{
    ArrayList questions = new ArrayList();
    int currQuestion = 0;
    int noQ;
    static Question instance = null;

    private Question(){
        loadQuestions();

        noQ = questions.Count;
    }

    public static Question getInstance(){
        if(instance == null){
            instance = new Question();
        }
        return instance;
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
            if (r.Equals("/END"))
            {
                break;
            }
            questions.Add(r);
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