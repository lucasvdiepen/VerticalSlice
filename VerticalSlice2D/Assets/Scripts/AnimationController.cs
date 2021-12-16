using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
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
    }
    public void PlayAnimation(string animation = "victory") 
    {
        characterAnim.SetTrigger(animation);
    }
}
