using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverMenu : MonoBehaviour
{
    public Animator hoverAnim;
   
    public void PlayAnim()
    {
        hoverAnim.SetBool("Hovering", true);
        Debug.Log("ON");
    }

    public void StopAnim()
    {
        hoverAnim.SetBool("Hovering", false);
        Debug.Log("OFF");
    }
}
