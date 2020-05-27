using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gong : MonoBehaviour
{


    [SerializeField] private float cycleTime = default;
    [SerializeField] private float dissipationTime = default;
    [SerializeField] private AudioClip sound = default;
    [SerializeField] private float waveScalingFactor = default;
    [SerializeField] private GameObject waveImage = default;


    private bool isRinging;
    private float currentCycleTime;
    private GameObject waveObject;
   
    private void Start()
    {
        waveObject = Instantiate(waveImage, transform.position,
               Quaternion.identity,transform);
        waveObject.transform.localScale = new Vector3(0, 0, 1);

    }

    void ProgpagateSoundWave()
    {
        waveObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1 ,1 - currentCycleTime / dissipationTime);
        waveObject.transform.localScale += Time.deltaTime/currentCycleTime * new Vector3(Time.deltaTime, Time.deltaTime, 0) * waveScalingFactor;
    }

    void StartSoundWave()
    {
       
        currentCycleTime = 0;
        isRinging = true;
        waveObject.SetActive(true);
        waveObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        waveObject.transform.localScale = new Vector3(0, 0, 1);
       
        GetComponent<AudioSource>().PlayOneShot(sound);
        
    }


    void StopSoundWave()
    {
        waveObject.SetActive(false);

    }

    void Update()
    {
        if (!isRinging)
        { 
            StartSoundWave();
        }
        else
        {
            currentCycleTime += Time.deltaTime;
            if (currentCycleTime < dissipationTime)
            {
                ProgpagateSoundWave();
            }
            else
            {
                StopSoundWave();
            }
            if (currentCycleTime > cycleTime)
            {
                isRinging = false;
            }
            
        }
    }

    
}
