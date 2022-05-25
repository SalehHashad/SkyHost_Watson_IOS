using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChangerScript : MonoBehaviour
{
    public static AnimationChangerScript instance;

    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
   
    public void ChangeAnim()
    {
        animator.SetTrigger("Wave");
    }

}
