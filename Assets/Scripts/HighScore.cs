using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public CharController distanceUnit;
    public TextMeshProUGUI SText;
    public TextMeshProUGUI HSText;

    private void Start()
    {
        distanceUnit= GetComponent<CharController>();
    }

    private void Update()
    {
        SText.text = distanceUnit.ToString();
    }

}
