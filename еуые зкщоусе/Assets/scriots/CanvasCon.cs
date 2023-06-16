using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCon : MonoBehaviour
{
    public GameObject panel;
    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
