using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipLantern : MonoBehaviour
{
    public Animator lanternEquip;
    // Start is called before the first frame update
    public void EquipTheLantern()
    {
        lanternEquip.SetBool("EquipLantern", true);
    }
}
