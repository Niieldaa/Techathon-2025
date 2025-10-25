using System.Text;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffectsPlayer : MonoBehaviour
{
    Timer timer;
    bool functionstarted;
    public GameObject audioobject;
    AudioSource audiosource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        functionstarted = false;
        audiosource = audioobject.GetComponent<AudioSource>();
        timer = gameObject.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer.GetTime() <= 0 && !functionstarted)
        {
            functionstarted = true; 
            audiosource.Play();

        }
    }
}
