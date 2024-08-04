using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject pause;
    public Button button;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        button.onClick.AddListener(OnButtonClick);
    }
    void OnButtonClick()
    {
        Debug.Log("Clicked");
    }
    public void Pause()
    {
        play.SetActive(true);
        Time.timeScale = 0f;
        pause.SetActive(false);
    }

    public void Continues()
    {
        pause.SetActive(true);
        Time.timeScale = 1f;
        play.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
