using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    #region singleton
    public static CoinManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    [SerializeField] TextMeshProUGUI text;
    public int currentAmount = 0;

    private void Start()
    {
        AddCoins(0);
    }

    public void AddCoins(int coins)
    {
        currentAmount += coins*2;
        text.text = $"Coins: {currentAmount}";
    }


}
