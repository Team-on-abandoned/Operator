using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMovement playerMovement;
    public TextMeshProUGUI cameraTipText;

    private void Awake()
    {
        instance = this;
    }
}
