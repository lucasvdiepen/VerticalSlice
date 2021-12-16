using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool isRunning;
    private Animator characterAnim;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Awake() 
    {
        characterAnim = gameObject.GetComponent<Animator>();
        characterAnim.SetTrigger("idle");
    }
    private void Update() {
        /*if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PlayAnimation();
           
        }*/

        if (isRunning) {
            rectTransform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime;
        }
    }
    public void PlayAnimation(string animation = "victory") 
    {
        characterAnim.SetTrigger(animation);
    }

    public void Run() 
    {
        isRunning = true;   
    }
}
