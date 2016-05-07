using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour {

	public void OnClick_Jouer(string name)
    {
        SceneManager.LoadScene("MainLevel");
    }
}
