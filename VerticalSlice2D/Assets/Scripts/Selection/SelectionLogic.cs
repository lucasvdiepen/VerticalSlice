using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLogic : MonoBehaviour
{
    [HideInInspector] public string character;
    private bool canSelect;
    private AudioManager audioManager;
    [SerializeField] private Color unselected, selected;
    [SerializeField] private int direction;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private Image currentSprite;
    [SerializeField] private Animator selectionAnim;

    private void Awake() 
    {
        character = gameObject.tag;
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
