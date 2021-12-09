using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemySelectionLogic : MonoBehaviour
{
    private GameObject selectedEnemy;
    private AudioManager audioManager;
    [SerializeField] private GameObject thisCharacter;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Color unselected, selected;
    [SerializeField] private int direction;
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();
    [SerializeField] private Image currentSprite;


    private void Awake() {
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
            selectedEnemy = enemies[1];
        }
        else if(currentSprite == buttons[0].GetComponent<Image>()){
            //seceond enemy
            selectedEnemy = enemies[0];
        }
        transform.parent.gameObject.SetActive(false);
    }
    public GameObject GetSelectedEnemy() {
        return selectedEnemy;
    }
    public GameObject GetPerson() {
        return thisCharacter;
    }
}
