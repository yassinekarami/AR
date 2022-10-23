using Utils;
using System.Collections.Generic;
namespace Utils.Question
{
    public class Question
    {
        public string identifiant;

        public string libelle;
        public List<Choix> choices { get; set; }

        public Question()
        {

        }
        public Question(List<Choix> choices, string libelle)
        {
            this.choices = choices;
            this.libelle = libelle;
        }
    }
}

