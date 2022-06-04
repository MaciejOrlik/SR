using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public LapComplete coin;
    public GameObject Coin;
    public GameObject coinPlayer;

    private void OnTriggerEnter(Collider other)
    {
        Coin.SetActive(false);
        coin.coin++;
        coinPlayer.GetComponent<AudioSource>().Play();
    }


}
