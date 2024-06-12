using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayCurrencyBalance : MonoBehaviour
{
    private DisplayCurrencyBalance displayCurrencyBalance;
    [SerializeField] private string playFabTitleId = "YOUR_TITLE_ID_HERE";
    [SerializeField] private string currencyId = "YOUR_CURRENCY_ID_HERE"; // Substitua pelo ID da moeda virtual na PlayFab
    public Text currencyText;
    //public TMP_Text textMeshPro;
    public int currencyAmount;
    public bool _launchpad;
    int valueLocal;
    private void Awake()
    {
        displayCurrencyBalance = this;
    }
    private void Start()
    {
        // Configurar as chaves de API da PlayFab
        PlayFabSettings.TitleId = playFabTitleId;
        GetCurrencyBalance();
    }

    public void GetCurrencyBalance()
    {
        var request = new GetUserInventoryRequest();

        PlayFabClientAPI.GetUserInventory(request, OnGetInventorySuccess, OnGetInventoryError);
    }

    private void OnGetInventorySuccess(GetUserInventoryResult result)
    {
        if (result.VirtualCurrency.TryGetValue(currencyId, out int balance))
        {
            Debug.Log("Saldo da moeda '" + currencyId + "': " + balance);
            if(_launchpad == true)
            {
                valueLocal = balance * 30;
                currencyText.text = valueLocal.ToString();
            }
            if (_launchpad == false)
            {
                currencyText.text = balance.ToString();
            }
            currencyAmount = balance;
            // Aqui você pode usar o valor 'balance' como quiser, como exibindo-o na interface do usuário.
        }
        else
        {
            Debug.LogWarning("O jogador não possui a moeda '" + currencyId + "' ou ela ainda não foi configurada corretamente.");
            currencyText.text = "O jogador não possui a moeda";
        }
    }

    private void OnGetInventoryError(PlayFabError error)
    {
        Debug.LogError("Erro ao obter inventário do jogador: " + error.GenerateErrorReport());
        currencyText.text = "Erro ao obter inventário do jogador";
    }
}

