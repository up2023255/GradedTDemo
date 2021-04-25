using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverMenu : MonoBehaviour
{
    public Animator hoverAnim;

   
    void Start()
    {
        
    }
    void Update()
    {
        

    }
    public void PlayAnim()
    {
        hoverAnim.SetTrigger("Hover");
    }
}
