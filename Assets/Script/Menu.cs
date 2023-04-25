using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private GameObject _menuButton;

    [SerializeField] private List<MonoBehaviour> _listToDisableforPause;

    public void OpenMenuWindow()
    {
        _menuButton.SetActive(false);
        _menuWindow.SetActive(true);
        _listToDisableforPause.ForEach(i => i.enabled = false);
        Time.timeScale = 0.01f;
    }
    public void CloseMenuWindow()
    {
        _menuButton.SetActive(true);
        _menuWindow.SetActive(false);
        _listToDisableforPause.ForEach(i => i.enabled = true);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
