using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemySelectionLogic : MonoBehaviour
{
    private string character;
    private AudioManager audioManager;
    [SerializeField] private GameObject thisCharacter;
    [SerializeField] private Color unselected, selected;
    [SerializeField] private int direction;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private Image currentSprite;

    private void Awake() {
        character = thisCharacter.tag;
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        UpdateDirection();
    }
    // Update is called once per frame
    private void Update() {
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
        if (Input.GetKeyDown(KeyCode.Space)) {
            ExecuteButton();
        }
    }
    private void UpdateDirection() {
        //audioManager.Play("Blip");
        currentSprite = buttons[direction].GetComponent<Image>();
        SetSelectedButton();
    }
    private void SetSelectedButton() {
        foreach (GameObject button in buttons) {
            button.GetComponent<Image>().color = selected;
        }
        currentSprite.color = unselected;
    }
    private void ExecuteButton() {
        if(currentSprite == buttons[1].GetComponent<Image>()) {
            //first enemy
            print("second enemy");
        }
        else if(currentSprite == buttons[0].GetComponent<Image>()){
            //seceond enemy
            print("first enemy");
        }
    }
}
