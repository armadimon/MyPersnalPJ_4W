using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour
{
    public GameObject panel;

    public void Activate()
    {
        panel.SetActive(true);
    }

    public void Deactivate()
    {
        panel.SetActive(false);
    }
}
