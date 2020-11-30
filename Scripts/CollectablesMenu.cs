using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesMenu : MonoBehaviour
{
	public Text currencyPlayerNameInfoText;
	public Text currencyCoinsUserInfoText;

    // Update is called once per frame
    void Start()
    {
        //currencyCoinsUserInfoText.text = "Itens coletados : " + GameManager.Instance.currency.ToString ();
    	//currencyPlayerNameInfoText.text = "Nome : " + GameManager.Instance.currentPlayerName.ToString ();
    }

    void Update () {
   		//currencyCoinsUserInfoText.text = "Itens coletados : " + GameManager.Instance.currency.ToString ();

    }
}
