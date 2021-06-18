//By Zoe Olive Straw

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class plyrHealth : MonoBehaviour
{
    #region flicker variables
    [SerializeField] float iFrameLength; //Total time angus will flash iFrames
    [SerializeField] float flickerLength; //The time of individual flickers while iFrames are flashing
    [SerializeField] GameObject angusModel; //The model we will turn on and off while flickering
    [SerializeField] int maxHealth;

    [SerializeField] Sprite pepperFull;
    [SerializeField] Sprite pepperEmpty;
    [SerializeField] Image[] pepperUISprites;
    private Color transparent = new Color(1,1,1,0);
    private Color white = new Color(1,1,1,1);
    private int currentHealth;

    private PlayerSpawner spawner;
    #endregion

    private InputManager controls;

    void Awake()
    {
        controls = new InputManager();
        controls.Player.DebugiFrames.performed += _ => Flicker();
        spawner = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerSpawner>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        RenderHealth();
    }

    public void TakeDamage(int damage)
    {
        //Placeholder function for when damage is implemented
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.tag == "DeathVolume")
        {
            RespawnAngus();
        }
    }

    private void RespawnAngus()
    {
        spawner.RespawnAngus();
    }

    #region UI

    void RenderHealth()
    {
        for(int i = 0; i < pepperUISprites.Length; i++)
        {
            if(i < currentHealth)
            {
                pepperUISprites[i].color = white;
                pepperUISprites[i].sprite = pepperFull;
            }
            else if(i < maxHealth)
            {
                pepperUISprites[i].color = white;
                pepperUISprites[i].sprite = pepperEmpty;
            }
            else
            {
                pepperUISprites[i].color = transparent;
                pepperUISprites[i].sprite = null;
            }
        }
    }

    #endregion
    
    #region Flicker Methods
    public void Flicker() //Call this method to play the iFrames that will also impact vulnerability (not yet implemented)
    {
        StartCoroutine(StartFlicker());
    }
    private IEnumerator StartFlicker() //This coroutine enables and disables the model giving the appearance of iFrame enabling / disabling
    {
        float currentLength = 0f;

        while(currentLength < iFrameLength)
        {
            angusModel.SetActive(!angusModel.activeSelf);
            currentLength += flickerLength;
            yield return new WaitForSeconds(flickerLength);
        }
        angusModel.SetActive(true);
    }
    #endregion
    
    #region on Enable / Disable
    void OnEnable()
    {
        controls.Enable();
    }
    void OnDisable()
    {
        controls.Disable();
    }
    #endregion
}
