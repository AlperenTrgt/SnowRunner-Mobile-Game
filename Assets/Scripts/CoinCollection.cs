using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollection : MonoBehaviour
{
    private AudioSource coin;
    public int coinNum = 0;
    private int totalcoin;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI EndcoinText;
    [SerializeField] public GameObject CoinImage;
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coin = GetComponent<AudioSource>();
        totalcoin = PlayerPrefs.GetInt("TotalCoin", 0); // Load total coin count from PlayerPrefs
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coin.Play();
            coinNum++;
            totalcoin++;
            PlayerPrefs.SetInt("TotalCoin", totalcoin); // Save total coin count to PlayerPrefs
        }
    }

    private void Update()
    {
        if (anim.GetBool("GameStart"))
        {
            CoinImage.SetActive(true);
            coinText.text = totalcoin.ToString();
            EndcoinText.text = totalcoin.ToString();
        }
    }
}

