using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

[CreateAssetMenu(fileName = "SubtractCurrencyData", menuName = "PlayFab/Subtract Currency Data")]
public class SubtractCurrencyData : ScriptableObject
{
    [SerializeField] private string playFabTitleId = "4859E";
    [SerializeField] private string currencyId = "YOUR_CURRENCY_ID_HERE"; // Substitua pelo ID da moeda virtual na PlayFab
    [SerializeField]
    public int amountToSubtract; // Altere a quantidade que você deseja subtrair
    private static SubtractCurrencyData _instance;


    public bool _onCurrencySubtracted;
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        // Configurar as chaves de API da PlayFab
        PlayFabSettings.TitleId = playFabTitleId;
    }

    public void SubtractCurrencyFromPlayer()
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = currencyId,
            Amount = amountToSubtract
        };

        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnCurrencySubtracted, OnCurrencySubtractError);
    }
    public void SubtractCurrencyFromPlayerSwap(int value)
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = currencyId,
            Amount = value
        };

        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnCurrencySubtracted, OnCurrencySubtractError);
    }
    private void OnCurrencySubtracted(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Moeda subtraída com sucesso! Nova quantidade: " + result.Balance);
        _onCurrencySubtracted = true;
    }

    private void OnCurrencySubtractError(PlayFabError error)
    {
        Debug.LogError("Erro ao subtrair moeda: " + error.GenerateErrorReport());
    }
}
