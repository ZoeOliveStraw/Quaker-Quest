using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject pnlTopMenu;
    [SerializeField] GameObject pnlOptionsMenu;
    private SceneLoader _manager;

    private void Start() 
    {
        _manager = GameObject.Find("Game Manager").GetComponent<SceneLoader>();
    }

    public void ActivateOptionsMenu()
    {
        pnlTopMenu.SetActive(false);
        pnlOptionsMenu.SetActive(true);
    }

    public void ActivateTopMenu()
    {
        pnlTopMenu.SetActive(true);
        pnlOptionsMenu.SetActive(false);
    }

    public void LoadFirstLevel()
    {
        _manager.LoadScene(1);
    }
}
