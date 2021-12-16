using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public bool isRunning;
    private Animator characterAnim;
    private void Awake() 
    {
        characterAnim = gameObject.GetComponent<Animator>();
        characterAnim.SetTrigger("idle");
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PlayAnimation();
           
        }

        if (isRunning) {
            transform.position += new Vector3(1, 0, 0);
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
