using System.Collections.Generic;
using Utils.Question;
public class Response
{
    public List<Question> questions;

    public Response()
    {
        questions = new List<Question>();
    }
    public Response(List<Question> questions)
    {
        this.questions = questions;
    }

    public void addQuestion(Question question)
    {
        questions.Add(question);
    }

    public void save()
    {

    }

}
