using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    [SerializeField]
    private GameObject GameStartPanel;
    [SerializeField]
    private GameObject GameSelectionPanel;
    [SerializeField]
    private GameObject SettingsPanel;
  
    public void Play()
    {
        GameStartPanel.SetActive(false);
        GameSelectionPanel.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }
    public void PlayShootout()
    {
        GameSelectionPanel.SetActive(false);
    }
    public void PlayKeeper()
    {
        GameSelectionPanel.SetActive(false);
        SceneManager.LoadScene("select");
    }
    public void BackSettings()
    {
        SettingsPanel.SetActive(false);
    }


}
