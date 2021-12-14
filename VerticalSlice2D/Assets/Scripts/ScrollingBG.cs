using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Renderer _renderer;
    private Animator bgAnim;

    private void Awake() 
    {
        bgAnim = gameObject.GetComponent<Animator>();
        _renderer = gameObject.GetComponent<Renderer>();
    }
    // Update is called once per frame
    private void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime);
    }
    public void ToggleGrid(bool OpenClose)
    {
        if (OpenClose && bgAnim != null) 
        {
            //open
            bgAnim.SetTrigger("Close");
        }
        else 
        {
            //close
            bgAnim.SetTrigger("Open");
        }
    }
}
