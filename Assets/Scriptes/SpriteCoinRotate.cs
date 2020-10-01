using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteCoinRotate : MonoBehaviour
{
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("rotate", true);
    }
}
