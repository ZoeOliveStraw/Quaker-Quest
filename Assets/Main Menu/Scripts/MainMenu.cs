using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject pnlTopMenu;
    [SerializeField] GameObject pnlOptionsMenu;
    [SerializeField] AudioClip music;
    private AudioSource _source;
    private SceneLoader _manager;

    private void Start() 
    {
        _manager = GameObject.Find("Game Manager").GetComponent<SceneLoader>();
        _source = GetComponent<AudioSource>();
        _source.clip = music;
        _source.Play();
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
