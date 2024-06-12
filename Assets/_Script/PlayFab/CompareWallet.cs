using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompareWallet : MonoBehaviour
{
    //public string setScene;
    public GameObject error;
    public GameObject mainPanel;
    public GameObject panelCompareWallet;
    public GameObject panelMainHUB;
    public Text walletPlayFab;
    public Text walletAtual;
  
    void Start()
    {
        walletPlayFab.text = PlayerPrefs.GetString("Wallet");
        walletAtual.text = PlayerPrefs.GetString("Account");
        //if (PlayerPrefs.GetString("Account") == PlayerPrefs.GetString("Wallet"))
        //{
        //    //StartCoroutine(LoadScene(8f));
        //    panelCompareWallet.SetActive(false);
        //    panelMainHUB.SetActive(true);
        //    Debug.Log("Foi");
        //    Debug.Log(PlayerPrefs.GetString("Account"));
        //    Debug.Log(PlayerPrefs.GetString("Wallet"));
        //}
        //else
        //{
        //    Debug.Log("Não Foi");
        //    error.SetActive(true);
        //    mainPanel.SetActive(false);
        //}
        panelCompareWallet.SetActive(false);
        panelMainHUB.SetActive(true);
    }
    //IEnumerator LoadScene(float _time)
    //{
    //    yield return new WaitForSeconds(_time);
    //    SceneManager.LoadScene(setScene);
    //}
}
