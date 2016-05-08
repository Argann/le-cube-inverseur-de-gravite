using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionManager : MonoBehaviour {

    [SerializeField]
    private Toggle musique_toggle;
    [SerializeField]
    private Toggle sons_toggle;
    [SerializeField]
    private AudioSource musique;
    [SerializeField]
    private GameObject ecran_options;

    // Use this for initialization
    void Start () {
        musique_toggle.isOn = PlayerPrefs.GetInt("musique", 1) == 0;
        sons_toggle.isOn = PlayerPrefs.GetInt("sons", 1) == 0;
    }

    public void OnValueChanged_Musique()
    {
        PlayerPrefs.SetInt("musique", (musique_toggle.isOn ? 0 : 1));
        if (musique_toggle.isOn)
        {
            musique.Stop();
        }
        else if (!musique.isPlaying)
        {
            musique.Play();
        }
    }

    public void OnValueChanged_Sons()
    {
        PlayerPrefs.SetInt("sons", (sons_toggle.isOn ? 0 : 1));
    }

    public void OnClick_Retour()
    {
        ecran_options.SetActive(false);
    }
}
