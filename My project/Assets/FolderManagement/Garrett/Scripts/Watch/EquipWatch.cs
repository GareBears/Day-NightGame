using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWatch : MonoBehaviour
{
    public Animator watchEquip;
    ///////////////////////////////////////////////////////////////////////////////
    public void EquipTheWatch()
    {
        watchEquip.SetBool("EquipWatch", true);
    }
}
