using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    public LapComplete coin;
    public TextMeshProUGUI coinDisplay;

    public LapComplete checkpointcounter;

    public TextMeshProUGUI checkpointDisplay;

    int multiply; 

    // Update is called once per frame
    void Update()
    {
        multiply = coin.coin * 5;

        coinDisplay.text = multiply.ToString(); 

        checkpointDisplay.text = checkpointcounter.checkpointcounter.ToString();  
        
    }
}
