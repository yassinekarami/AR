using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System;

using Utils.Question;
using Utils;
using SceneManagement.QuizzSceneManager;
using CustomEvent.IsOverEventArgument;

public class QuestionManager : MonoBehaviour
{
    // liste des questions qui seront afficher
    public static List<Question> questions;

    // liste des reponses qui seront enregistré
    public static Response responses;
    public static Text questionText;

    //timer du temps de réponse
    public static Text questionTimer;
    float timer = 0.0f;

    public List<Button> button;
    public bool isGameOver;


    public event EventHandler<IsOverEventArgument> onIsGameOverChanged;

    public static QuestionManager questionmanager;
    FirebaseManager firebase = FirebaseManager.getInstance();
    private void Awake()
    {
        questionTimer = GameObject.Find("TimerText").GetComponent<Text>();
        questionText = GameObject.Find("QuestionText").GetComponent<Text>();
        questionmanager = getInstance();
        setUpQuestion();
    }

    public static QuestionManager getInstance()
    {
        if (questionmanager == null)
        {
            return new QuestionManager();
        }
        else 
        {
            return questionmanager;
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
         //   FirebaseManager.fireBaseManager.saveResponse(responses);
        }
        try
        {
           timer = 0;
           Question q = questions[0];
           Debug.Log(q.libelle);
           questionText.text = q.libelle;
           for (int i = 0; i < q.choices.Count; i++)
           {
                button[i].GetComponent<ButtonScript>().Init(q.choices[i]);
           }
           questions.RemoveAt(0);
        } catch(ArgumentOutOfRangeException e)
        {
            onIsGameOverChanged?.Invoke(this, new IsOverEventArgument { isGameOver = true });
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
