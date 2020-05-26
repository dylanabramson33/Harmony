using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StandardBirdRing : Ringable
{

    [SerializeField] private float dissipationTime = default;
    [SerializeField] private AudioClip sound = default;
    [SerializeField] private float waveScalingFactor = default;
    [SerializeField] private GameObject waveImage = default;


    private bool shouldRing;
    private float currentCycleTime;
    private GameObject waveObject;
    private bool ringing;



    void StartSoundWave()
    {
        currentCycleTime = 0;
        waveObject.SetActive(true);
        waveObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        waveObject.transform.localScale = new Vector3(0, 0, 1);
        
        GetComponent<AudioSource>().PlayOneShot(sound);
        
        ringing = true;
        shouldRing = false;
    }

    void ProgpagateSoundWave()
    {
        waveObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - currentCycleTime / dissipationTime);
        waveObject.transform.localScale += Time.deltaTime/currentCycleTime * new Vector3(Time.deltaTime, Time.deltaTime, 0) * waveScalingFactor;
    }

  
    void StopSoundWave()
    {
        waveObject.SetActive(false);
        ringing = false; 

    }

    private void Start()
    {
        waveObject = Instantiate(waveImage, transform.position,
               Quaternion.identity, transform);
        waveObject.transform.localScale = new Vector3(0, 0, 1);

    }

    private void Update()
    {
        if (shouldRing)
        {
            StartSoundWave();
        }
        else if(ringing)
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
          
        }
    }


    public override void Ring()
    {
        shouldRing = true;
    }
}