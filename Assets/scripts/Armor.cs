using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Armor : MonoBehaviour
{

    public TextMeshProUGUI armor;

    public void updateArmor(int _armor)
    {
        armor.text = "" + _armor;
    }
}
