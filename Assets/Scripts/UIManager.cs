using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _coinText;
    [SerializeField] Text _livesText;

    public void UpdateCoinText(int coins)
    {
        _coinText.text = coins.ToString();
    }

    public void UpdateLivesText(int lives)
    {
        _livesText.text = lives.ToString();
    }
}
