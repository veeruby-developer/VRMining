using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionScript : MonoBehaviour
{
    public GameObject welcomeCanvas,prosNconsCanvas;
    GameObject benchHighlight;
    GameObject crestHighlight,toeHighlight,benchfaceHighlight,benchfloorHighlight,haulHighlight,rampHighlight,orebodyHighlight;
    AudioSource audioSource;
    public AudioClip[] clips;
    public AudioClip defaultClip;
    int clipIndex;

    // Assigning declared objects
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = defaultClip;
        audioSource.Play();

        benchHighlight = GameObject.Find("Bench");
        benchHighlight.SetActive(false);

        crestHighlight = GameObject.Find("Crest");
        crestHighlight.SetActive(false);

        toeHighlight = GameObject.Find("Toe");
        toeHighlight.SetActive(false);

        benchfaceHighlight = GameObject.Find("Bench Face");
        benchfaceHighlight.SetActive(false);

        benchfloorHighlight = GameObject.Find("Bench Floor");
        benchfloorHighlight.SetActive(false);

        haulHighlight = GameObject.Find("Haul Road");
        haulHighlight.SetActive(false);

        rampHighlight = GameObject.Find("Ramp");
        rampHighlight.SetActive(false);

        orebodyHighlight = GameObject.Find("Orebody");
        orebodyHighlight.SetActive(false);
    }

    //Setting up the position of player in front of cave
    public void CaveFrontPos()
    {
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(32.08f, -9.8f, -9.39f);
        gameObject.transform.position = pos;
        gameObject.transform.Rotate(0, 150, 0);
        gameObject.SetActive(true);
        
    }

    //Setting up the position of player for air view
    public void AirView()
    {
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(-97.9f, 20.2f, 18.4f);
        gameObject.transform.position = pos;
        gameObject.transform.Rotate(0, -25, 0);
        gameObject.GetComponent<CharacterController>().enabled = false;
        gameObject.SetActive(true);
        welcomeCanvas.SetActive(true);
        audioSource.clip = clips[clipIndex];
        AudioChange();
        audioSource.Play();
        StartCoroutine(WelcomeCanvasOff());
        
    }
    
    //Change the audio wrt highlights descriptions
    void AudioChange()
    {
        
        audioSource.clip = clips[clipIndex];
        clipIndex = clipIndex + 1;
    }

    //Disabling the Welcome panel
    IEnumerator WelcomeCanvasOff()
    {
        yield return new WaitForSeconds(5);
        welcomeCanvas.SetActive(false);
        StartCoroutine(Bench());
    }
    
    //Highlights enable and disable between few seconds delay - Bench,Crest,Toe,BenchFace,BenchFloor,HaulRoad,Ramp,OreBody
    IEnumerator Bench()
    {
        Debug.Log("bench");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        benchHighlight.SetActive(true);
        //Debug.Log("b");
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(-46.6f, 17.11f, -15f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        
        StartCoroutine(Crest());
    }
    IEnumerator Crest()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        benchHighlight.SetActive(false);
        crestHighlight.SetActive(true);
        StartCoroutine(Toe());
    }
    IEnumerator Toe()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        crestHighlight.SetActive(false);
        toeHighlight.SetActive(true);
        StartCoroutine(BenchFace());
    }
    IEnumerator BenchFace()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        toeHighlight.SetActive(false);
        benchfaceHighlight.SetActive(true);
        StartCoroutine(BenchFloor());
    }
    IEnumerator BenchFloor()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        benchfaceHighlight.SetActive(false);
        benchfloorHighlight.SetActive(true);
        StartCoroutine(HaulRoad());
    }
    IEnumerator HaulRoad()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        benchfloorHighlight.SetActive(false);
        haulHighlight.SetActive(true);
        StartCoroutine(Ramp());
    }
    IEnumerator Ramp()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        haulHighlight.SetActive(false);
        rampHighlight.SetActive(true);
        gameObject.transform.Rotate(0, 0, 0);
        StartCoroutine(OreBody());
    }
    IEnumerator OreBody()
    {
        yield return new WaitForSeconds(10);
        AudioChange();
        audioSource.Play();
        rampHighlight.SetActive(false);
        orebodyHighlight.SetActive(true);
        StartCoroutine(SumUp());
    }

    IEnumerator SumUp()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        orebodyHighlight.SetActive(false);
        prosNconsCanvas.SetActive(true);
    }
}
