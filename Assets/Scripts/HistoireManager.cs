using UnityEngine;
using System.Collections;

public class HistoireManager : MonoBehaviour {

    public GameObject histoire;

    public void OnClick_Retour()
    {
        histoire.SetActive(false);
    }
}
