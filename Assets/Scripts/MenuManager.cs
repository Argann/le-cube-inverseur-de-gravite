using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Text laBlague;
    [SerializeField]
    private Text highscore;
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private GameObject options;


	public void OnClick_Jouer()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnClick_Quitter()
    {
        Application.Quit();
    }

    public void OnClick_Options()
    {
        options.SetActive(true);
    }

    void Start()
    {
        options.SetActive(false);
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
        blagues.Add("STACKOVERFLOW EXCEPTION");
        blagues.Add("HELP !");
        blagues.Add("\"Ce n'est pas un boeuf à la fraise !\"");
        if (laBlague != null)
        {
            laBlague.text = blagues[Random.Range(0, blagues.Count)].ToString();
        }

        if (highscore != null)
        {
            highscore.text = "Highscore : " + PlayerPrefs.GetInt("highscore", 0);
        }
        if (PlayerPrefs.GetInt("musique", 1) == 0)
        {
            music.Stop();
        }
    }
}
