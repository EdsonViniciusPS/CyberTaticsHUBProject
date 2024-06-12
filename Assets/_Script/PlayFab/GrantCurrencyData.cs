using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

[CreateAssetMenu(fileName = "GrantCurrencyData", menuName = "PlayFab/Grant Currency Data")]
public class GrantCurrencyData : ScriptableObject
{
    [SerializeField] private string playFabTitleId = "4859E";
    [SerializeField] private string currencyId = "YOUR_CURRENCY_ID_HERE"; // Substitua pelo ID da moeda virtual na PlayFab
    [SerializeField]
    public int amountToAdd; // Altere a quantidade que você deseja adicionar
    private static GrantCurrencyData grantCurrencyData;

    private void Awake()
    {
        grantCurrencyData = this;
    }
    private void Start()
    {
        // Configurar as chaves de API da PlayFab
        PlayFabSettings.TitleId = playFabTitleId;
    }
  
    public void AddCurrency()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = currencyId,
            Amount = amountToAdd
        };

        PlayFabClientAPI.AddUserVirtualCurrency(request, OnCurrencyAdded, OnCurrencyAddError);
    }
    public void AddCurrencySwap(int value)
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = currencyId,
            Amount = value
        };

        PlayFabClientAPI.AddUserVirtualCurrency(request, OnCurrencyAdded, OnCurrencyAddError);
    }
    private void OnCurrencyAdded(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Moeda adicionada com sucesso! Nova quantidade: " + result.Balance);
    }

    private void OnCurrencyAddError(PlayFabError error)
    {
        Debug.LogError("Erro ao adicionar moeda: " + error.GenerateErrorReport());
    }
}
