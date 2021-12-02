using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLogic : MonoBehaviour
{
    [SerializeField] private Color unselected, selected;
    [SerializeField] private int direction;
    [SerializeField] private List<GameObject> Buttons = new List<GameObject>();
    [SerializeField] private Image currentSprite;


    private void Start() 
    {
        UpdateDirection();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //move right
            direction++;
            if (direction == Buttons.Count) 
            {
                direction = 0;
            }
            UpdateDirection();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            //move left
            direction--;
            if (direction == -1) 
            {
                direction = Buttons.Count -1;
            }
            UpdateDirection();
        }
    }
    private void UpdateDirection() 
    {
        FindObjectOfType<AudioManager>().Play("Blip");
        currentSprite = Buttons[direction].GetComponent<Image>();
        SetSelectedButton();
    }
    private void SetSelectedButton() 
    {
        foreach (GameObject button in Buttons) 
        {
            button.GetComponent<Image>().color = selected;
        }
        currentSprite.color = unselected;
    }
}
