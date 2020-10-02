using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Image pauseMenu;
    [SerializeField] private Image restartMenu;
    [SerializeField] private Image levelMenu;
    void Start()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    public void OnPauseClicked()
    {
        restartMenu.gameObject.SetActive(false);
        levelMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
