using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public GameObject[] heartIcons;
    public GameObject menuHolder;
    internal int selectedButton = 0;
    internal bool canInteract = false;

    public void OpenMenu()
    {
        menuHolder.SetActive(true);
        canInteract = true;
    }

    public void CloseMenu()
    {
        menuHolder.SetActive(false);
        canInteract = false;
    }

    private void Update()
    {
        RunInput();
    }

    public virtual void RunInput()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectedButton - 1 >= 0){ selectedButton -= 1; HandleSoundEffect(); };
                UpdateButtonSprite();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectedButton + 1 < heartIcons.Length) { selectedButton += 1; HandleSoundEffect(); };
                UpdateButtonSprite();
            }

            if (Input.GetKeyDown(KeyCode.Space)) ExecuteButton();
        }
    }

    public void HandleSoundEffect()
    {
        FindObjectOfType<AudioManager>().Play("Blip");
    }

    public void UpdateButtonSprite()
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (i == selectedButton) heartIcons[i].SetActive(true);
            else heartIcons[i].SetActive(false);
        }
    }

    public abstract void ExecuteButton();
}
