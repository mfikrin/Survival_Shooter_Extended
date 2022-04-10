using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ZenClickName : MonoBehaviour
{
    public TextMeshProUGUI Rank;
    public TextMeshProUGUI NickName;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI FullName;

    public void ZenOnClickNickName()
    {
        Rank.gameObject.SetActive(false);
        NickName.gameObject.SetActive(false);
        Time.gameObject.SetActive(false);
        FullName.gameObject.SetActive(true);
    }

    public void ZenOnClickFullName()
    {
        Rank.gameObject.SetActive(true);
        NickName.gameObject.SetActive(true);
        Time.gameObject.SetActive(true);
        FullName.gameObject.SetActive(false);
    }
}
