using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLogic : MonoBehaviour
{
    public string character;
    private bool canSelect;
    private AudioManager audioManager;
    [SerializeField] private Color unselected, selected;
    [SerializeField] private int direction = 0;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private Image currentSprite;
    [SerializeField] private Animator selectionAnim;
    [SerializeField] private Menu enemyMenu;
    [SerializeField] private Menu actMenu;

    private void Awake() 
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() 
    {
        UpdateDirection();
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            OpenMenu();
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            CloseMenu();
        }
        if (canSelect) {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                //move right
                direction++;
                if (direction == buttons.Count) {
                    direction = 0;
                }
                UpdateDirection();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                //move left
                direction--;
                if (direction == -1) {
                    direction = buttons.Count - 1;
                }
                UpdateDirection();
            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                ExecuteButton();
            }
        }
    }

    private void ExecuteButton()
    {
        switch(direction)
        {
            case 0:
                //Fight
                FindObjectOfType<ActionSaveManager>().AddAction(character, ActionSaveManager.ActionType.Fight);
                canSelect = false;
                enemyMenu.OpenMenu();
                break;
            case 1:
                //Act
                FindObjectOfType<ActionSaveManager>().AddAction(character, ActionSaveManager.ActionType.Act);
                canSelect = false;
                enemyMenu.OpenMenu();
                break;
            case 2:
                //Items
                break;
            case 3:
                //Spare
                FindObjectOfType<ActionSaveManager>().AddAction(character, ActionSaveManager.ActionType.Spare);
                canSelect = false;
                enemyMenu.OpenMenu();
                break;
            case 4:
                //Defend
                FindObjectOfType<ActionSaveManager>().AddAction(character, ActionSaveManager.ActionType.Defend);
                FindObjectOfType<PlayerSelector>().NextPlayer();
                break;
        }
    }

    private void UpdateDirection() 
    {
        //audioManager.Play("Blip");
        currentSprite = buttons[direction].GetComponent<Image>();
        SetSelectedButton();
    }
    private void SetSelectedButton() 
    {
        foreach (GameObject button in buttons) 
        {
            button.GetComponent<Image>().color = selected;
        }
        currentSprite.color = unselected;
    }
    public void OpenMenu() 
    {
        selectionAnim.SetTrigger("Open");
        canSelect = true;
    }
    public void CloseMenu() 
    {
        selectionAnim.SetTrigger("Close");
        canSelect = false;
    }
}
