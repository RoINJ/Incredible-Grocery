using System;
using UnityEngine;

public class StorageOpener : MonoBehaviour
{
    private Animator _animator;

    public bool IsOpened
    {
        get => _animator.GetBool(nameof(IsOpened));
        set => _animator.SetBool(nameof(IsOpened), value);
    }
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
