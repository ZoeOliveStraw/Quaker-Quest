using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject pnlTopMenu;
    [SerializeField] GameObject pnlOptionsMenu;



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
        SceneManager.LoadScene(1);
    }
}
