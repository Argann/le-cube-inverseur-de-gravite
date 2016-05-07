using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Text laBlague;
    [SerializeField]
    private Text highscore;


	public void OnClick_Jouer(string param)
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnClick_Quitter(string param)
    {
        print("OnClick_Quitter : quit !");
        Application.Quit();
    }

    void Start()
    {
        ArrayList blagues = new ArrayList();
        blagues.Add("Garantie sans écrou !");
        blagues.Add("VOUS AVEZ PERDU !");
        blagues.Add("Astuce : Les pics piquent !");
        blagues.Add("Astuce : Vous êtes le seul cube qui a des jambes dans le monde, utilisez les !");
        blagues.Add("C'est un aveugle qui rentre dans un bar. Puis dans une chaise, une table...");
        blagues.Add("MORDU. MORDU. MORDU.");
        blagues.Add("The cube is a lie !");
        blagues.Add("On a eu l'idée avant Mojang.");
        blagues.Add("\"5/7\" ~ IGN");
        blagues.Add("\"La 4K vieillit à côté de ce jeu.\" ~ Squeezie");
        blagues.Add("\"Une histoire émouvante, j'en ai les larmes aux yeux.\" ~ Arnold Schwarzenegger");
        blagues.Add("\"Le nouveau Call Of Duty !\" ~ Albert Einstein");
        blagues.Add("Fait par AlphaDreams, BenLatex et Excilyano.");
        if (laBlague != null)
        {
            laBlague.text = blagues[Random.Range(0, blagues.Count)].ToString();
        }

        if (highscore != null)
        {
            highscore.text = "Highscore : " + PlayerPrefs.GetInt("highscore", 0);
        }
    }
}
