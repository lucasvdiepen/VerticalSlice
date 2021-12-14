using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Renderer _renderer;

    private void Awake() {
        _renderer = gameObject.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        _renderer.material.mainTextureOffset += new Vector2(moveSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime);
    }
}
