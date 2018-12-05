using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question{
    ArrayList questions = new ArrayList();
    int currQuestion = 0;
    int noQ;

    public Question(){
        questions.Add("Klicka på badankan@badAnka");
        questions.Add("Klicka på ankan@anka");

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