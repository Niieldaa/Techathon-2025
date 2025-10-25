using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;
using System.Runtime.InteropServices.WindowsRuntime;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] float RemainingTime;

    // Update is called once per frame
    void Update()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
        }
        else
        {
            RemainingTime = 0;
            //GameOver();
            TimerText.color = Color.red;
        }

        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public float GetTime()
    {
        return RemainingTime;
    }
}
