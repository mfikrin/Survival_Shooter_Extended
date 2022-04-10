using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveClickName : MonoBehaviour
{
    public TextMeshProUGUI Rank;
    public TextMeshProUGUI NickName;
    public TextMeshProUGUI Wave;
    public TextMeshProUGUI Score;

    public TextMeshProUGUI FullName;
  

    public void WaveOnClickNickName()
    {
        Rank.gameObject.SetActive(false);
        NickName.gameObject.SetActive(false);
        Wave.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        FullName.gameObject.SetActive(true);

    }

    public void WaveOnClickFullName()
    {
        Rank.gameObject.SetActive(true);
        NickName.gameObject.SetActive(true);
        Wave.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        FullName.gameObject.SetActive(false);

    }
}
