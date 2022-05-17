using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletsCount : MonoBehaviour
{
    public TextMeshProUGUI Bullets;
    // Start is called before the first frame update
    void Start()
    {
        Bullets.text = "0";
    }

   public void updateGun(int bullets, int magazine, bool isReloading)
    {
        if (isReloading)
        {
            
            Bullets.text = "Reloading...";
            return;
        }
        Bullets.text = bullets + "/" + magazine;
    }
}
