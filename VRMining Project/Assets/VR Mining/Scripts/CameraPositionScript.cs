using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPositionScript : MonoBehaviour
{
    public GameObject welcomeCanvas,prosNconsCanvas;
    public GameObject MetalMinewelcomeCanvas, MetalMineprosNconsCanvas; //Underground Metal Mine 
    public AudioSource audioSource;
    GameObject benchHighlight;
    GameObject crestHighlight,toeHighlight,benchfaceHighlight,benchfloorHighlight,haulHighlight,rampHighlight,orebodyHighlight;
    GameObject cageHighlight,aditHighlight,backfillHighlight,depositHighlight,explosiveHighlight,trolleyHighlight,minerailwayHighlight; // Underground Metal Mine 
    AudioSource defaultAudioSource;
    AudioClip[] clips = new AudioClip[10];
    public AudioClip defaultClip;
    int clipIndex;

    // Assigning declared objects
    void Start()
    {
        for(int i = 0; i<=9; i++)
        {
            
                clips[i] = Resources.Load<AudioClip>("Audio Files/Walkthroughs/Opencast Mine/Opencast_" + i);
            Debug.Log(clips[i].name);

        }

        //audioSource = GameObject.Find("Hindi Audio Source ").GetComponent<AudioSource>();

        defaultAudioSource = gameObject.GetComponent<AudioSource>();
        defaultAudioSource.clip = defaultClip;
        defaultAudioSource.Play();

        benchHighlight = GameObject.Find("Mining_Bench_High");
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

        // Underground Metal Mine
        //cageHighlight = GameObject.Find("cage");
        //cageHighlight.SetActive(false);

        //aditHighlight = GameObject.Find("adit");
        //aditHighlight.SetActive(false);

        //backfillHighlight = GameObject.Find("Rusted_Pipe");
        //backfillHighlight.SetActive(false);

        //depositHighlight = GameObject.Find("deposit");
        //depositHighlight.SetActive(false);

        //explosiveHighlight = GameObject.Find("explosive");
        //explosiveHighlight.SetActive(false);

        //trolleyHighlight = GameObject.Find("trolley");
        //trolleyHighlight.SetActive(false);

        //minerailwayHighlight = GameObject.Find("minerailway");
        //minerailwayHighlight.SetActive(false);


    }

    void AudioChange()
    {

        audioSource.clip = clips[clipIndex];
        clipIndex = clipIndex + 1;
    }

    //SceneChange Method
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
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
        audioSource.Play();
        audioSource.clip = clips[clipIndex];
        Debug.Log(clipIndex);

        clipIndex++;
        

        defaultAudioSource.volume = 0.5f;
        StartCoroutine(WelcomeCanvasOff());
        
    }
    
    //Change the audio wrt highlights descriptions
    

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

    //Underground Metal Mine
     public void MetalMineCaveFrontPos()
    {
      
        StartCoroutine(MetalMineWelcomeCanvasOff());
        
    }

    IEnumerator MetalMineWelcomeCanvasOff()
    {
        yield return new WaitForSeconds(10);
        MetalMinewelcomeCanvas.SetActive(false);
        StartCoroutine(Adit());
    }

    IEnumerator Adit()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        aditHighlight.SetActive(true);
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(54.77f, -12.68f, -27.4f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(MineRailway());
    }

     IEnumerator MineRailway()
    {
        aditHighlight.SetActive(false);
        Debug.Log("MineRailway");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        minerailwayHighlight.SetActive(true);
        //Debug.Log("b");
        StartCoroutine( BackFill());
    }

    IEnumerator BackFill()
    {
        minerailwayHighlight.SetActive(false);
        Debug.Log("BackFill");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        backfillHighlight.SetActive(true);
        //Debug.Log("b");
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(87.17f, -12.36f, -46.79f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(Trolley());
    }

    IEnumerator Trolley()
    {
        backfillHighlight.SetActive(false);
        Debug.Log("Trolley");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        trolleyHighlight.SetActive(true);
        StartCoroutine(Explosive());
    }

    IEnumerator Explosive()
    {
        trolleyHighlight.SetActive(false);
        Debug.Log("Explosive");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        explosiveHighlight.SetActive(true);
        StartCoroutine(Deposit());
    }

     IEnumerator Deposit()
    {
        explosiveHighlight.SetActive(false);
        Debug.Log("Deposit");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        depositHighlight.SetActive(true);
        //Debug.Log("b");
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(-97.2f, -12.1f, -53.6f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(Cage());
    }


    IEnumerator Cage()
    {
        depositHighlight.SetActive(false);
        Debug.Log("Cage");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        cageHighlight.SetActive(true);
        StartCoroutine(Closure());
    }

    IEnumerator Closure()
    {
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        cageHighlight.SetActive(false);
        MetalMineprosNconsCanvas.SetActive(true);
    }
}
