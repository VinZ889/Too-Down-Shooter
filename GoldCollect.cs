using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCollect : MonoBehaviour
{
    int goldAmount;
    Text goldText;

    void Start()
    {
        goldText = GetComponent<Text>();
        goldText.text = goldAmount.ToString();
    }

    public void GoldGain(int goldGain)
    {
        goldAmount = goldAmount + goldGain;
        goldText.text = goldAmount.ToString();
    }
}
