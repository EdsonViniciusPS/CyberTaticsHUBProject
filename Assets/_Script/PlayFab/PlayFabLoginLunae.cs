using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabLoginLunae : MonoBehaviour
{
    [Header("UI Manager")]
    public GameObject panelError;
    public GameObject panelLoginPlayfab;
    public GameObject panelCompareWalletPanel;
    public GameObject panelMain;
    public InputField emailInput;
    public InputField passwordInput;
    public InputField nickName;
    public Text messageText;

    [Header("PlayFab Post")]
    public PlayerDataManager playerDataManager;
    [Header("PlayFab Get")]
    public PlayFabTitleData playFabTitleData;

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        //StartCoroutine(LoadScene(10f));
        panelCompareWalletPanel.SetActive(true);
        panelLoginPlayfab.SetActive(false);
        messageText.text = "Login Successful!";
        playFabTitleData.LoadTitleData();
        Debug.Log("Login Successful!");
    }
    private void OnLoginFailure(PlayFabError error)
    {
        panelError.SetActive(true);
        messageText.text = "Login failed: " + error.ErrorMessage;
        Debug.LogError("Login failed: " + error.ErrorMessage);
    }
    //Register
    public void Register()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            Username = nickName.text // Define o nome do jogador durante o cadastro
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        //StartCoroutine(LoadScene(8f));
        //panelCompareWalletPanel.SetActive(true);
        panelMain.SetActive(true);
        panelLoginPlayfab.SetActive(false);
        messageText.text = "Registration Successful!";
        playerDataManager.SavePlayerAdditionalInfo(PlayerPrefs.GetString("Account"));
        Debug.Log("Registration Successful!");
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        panelError.SetActive(true);
        messageText.text = "Registration failed: " + error.ErrorMessage;
        Debug.LogError("Registration failed: " + error.ErrorMessage);
    }
    //Load Scene
    //IEnumerator LoadScene(float _time)
    //{
    //    yield return new WaitForSeconds(2.5f);
    //    panelLoad.SetActive(true);
    //    yield return new WaitForSeconds(_time);
    //    //SceneManager.LoadScene(setScene);
    //}
}
