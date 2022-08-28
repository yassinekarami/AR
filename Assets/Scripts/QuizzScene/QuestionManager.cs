using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System;

using Utils.Question;
using Utils.Reponse;
public class QuestionManager : MonoBehaviour
{
    // liste des questions qui seront afficher
    public List<Question> questions;

    // liste des reponses qui seront enregistré
    public Response responses;
    public Text questionText;

    //timer du temps de réponse
    public Text questionTimer;
    float timer = 0.0f;

    public List<Button> button;

    public Action<QuizzManager, bool> onIsOverChange;
    QuizzManager quizzManager = QuizzManager.getInstance();

    public static QuestionManager questionmanager;
    private void Awake()
    {
 
        setUpQuestion();
        questionmanager = getInstance();
    }

    public static QuestionManager getInstance()
    {
        if (questionmanager == null)
        {
            return new QuestionManager();
        }
        else 
        {
            return QuestionManager.questionmanager;
        }
    }

    void Start()
    {
        responses = new Response();
        StartCoroutine(getNextQuestion());
    }

    /**
     * Parse les questions contenu dans le json
     */
    void setUpQuestion()
    {
        TextAsset jsonTextFile = Resources.Load<TextAsset>("questions");
        questions = JsonConvert.DeserializeObject<List<Question>>(jsonTextFile.ToString());
    }
   
    private void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        questionTimer.text = seconds.ToString();
        if (seconds.Equals(5))
        {
      
            StartCoroutine(getNextQuestion());
        }
    }

  
    /**
     * alimente le tableau de reponse et passe a la question suivante
     */
    public void getAnswer(Choix choix)
    {
        List<Choix> c = new List<Choix>();
        c.Add(choix);
        alimenterReponse(questionText.text, c);

        getNextQuestion();
    }

    /**
     * retourne la question suivate 
     * 
     */
    IEnumerator getNextQuestion()
    {
        yield return new WaitForSeconds(0.5f);
        if(questions.Count <= 0)
        {
            FirebaseManager.fireBaseManager.saveResponse(responses);
        }
        try
        {
           timer = 0;
           Question q = questions[0];
           questionText.text = q.libelle;
           for (int i = 0; i < q.choices.Count; i++)
           {
                button[i].GetComponent<ButtonScript>().Init(q.choices[i]);
           }
            questions.RemoveAt(0);
        } catch(ArgumentOutOfRangeException e)
        {
            quizzManager.isOverChangeEvent += (s, args) => { };
            quizzManager.onIsOverChange(false);

        }
    }

    /**
     * alimente le tableau de reponse qui sera sauvegarder en base
     */
    private void alimenterReponse(String questionLib, List<Choix> choix)
    {
        Question q = new Question(choix, questionLib);
        responses.addQuestion(q);
    }

}
