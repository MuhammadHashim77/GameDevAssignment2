using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    private int count = 0;
    [SerializeField] private Text coinText;
    [SerializeField] private AudioClip coinAudio;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        coinText.text = "Coins: " + count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            count++;
            coinText.text = "Coins: " + count.ToString();
            source.PlayOneShot(coinAudio, 0.4f);
            Destroy(other.gameObject);
        }
    }
}
