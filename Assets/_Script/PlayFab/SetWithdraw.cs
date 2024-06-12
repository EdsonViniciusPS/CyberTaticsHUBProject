using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWithdraw : MonoBehaviour
{
    public DisplayCurrencyBalance displayCurrencyBalance;
    public GameObject button;
    public GameObject aviso;

    private void Start()
    {
        setWithdraw();
    }
    public void setWithdraw()
    {
        if(displayCurrencyBalance.currencyAmount >= 18)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
            aviso.SetActive(true);
        }
    }
}
