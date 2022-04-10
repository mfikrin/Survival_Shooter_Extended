using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SuddenDeathClickName : MonoBehaviour
{
    public TextMeshProUGUI Rank;
    public TextMeshProUGUI NickName;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Time;

    public TextMeshProUGUI FullName;


    public void SuddenOnClickNickName()
    {
        Rank.gameObject.SetActive(false);
        NickName.gameObject.SetActive(false);
        Score.gameObject.SetActive(false);
        Time.gameObject.SetActive(false);
        FullName.gameObject.SetActive(true);

    }

    public void SuddenOnClickFullName()
    {
        Rank.gameObject.SetActive(true);
        NickName.gameObject.SetActive(true);
        Score.gameObject.SetActive(true);
        Time.gameObject.SetActive(true);
        FullName.gameObject.SetActive(false);

    }
}
