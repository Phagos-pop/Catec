using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoot : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _isRight;
    public void LeftHand()
    {
        _animator.SetTrigger("LeftHand");
    }
    public void RightHand()
    {
        _animator.SetTrigger("RightHand");
    }

    public void NextHand()
    {
        if (_isRight)
        {
            RightHand();
            _isRight = false;
        }
        LeftHand();
        _isRight = true;
    }
}
