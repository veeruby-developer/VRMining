using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPositionScript : MonoBehaviour
{
    //Common Import
    public AudioSource audioSource;
    AudioSource defaultAudioSource;
    AudioClip[] clips = new AudioClip[10];
    public AudioClip defaultClip;
    int clipIndex;

    //Opencast Mine
    public GameObject welcomeCanvas,prosNconsCanvas;
    GameObject benchHighlight;
    GameObject crestHighlight,toeHighlight,benchfaceHighlight,benchfloorHighlight,haulHighlight,rampHighlight,orebodyHighlight;
    

    //Underground Metal Mine 
    public GameObject MetalMinewelcomeCanvas, MetalMineprosNconsCanvas; 
    GameObject aditHighlight; 
    


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
        aditHighlight = GameObject.FindGameObjectWithTag("Adit Highlight");
        aditHighlight.SetActive(false);


    }
    //Change the audio wrt highlights descriptions
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
        MetalMinewelcomeCanvas.SetActive(true);
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(39, -11f, -17);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);

        StartCoroutine(MetalMineWelcomeCanvasOff());
        
    }

    IEnumerator MetalMineWelcomeCanvasOff()
    {
        AudioChange();
        audioSource.Play();
        yield return new WaitForSeconds(5);
        MetalMinewelcomeCanvas.SetActive(false);
        StartCoroutine(Adit());
    }

    IEnumerator Adit()
    {
        AudioChange();
        audioSource.Play();
        aditHighlight.SetActive(true);
        Debug.Log("Adit");
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(51, -11f, -25);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(MineRailway());
    }

     IEnumerator MineRailway()
    {
        
        Debug.Log("track");
        aditHighlight.SetActive(false);         
        AudioChange();
        audioSource.Play();
        Material track = Resources.Load<Material>("Highlight Materials/Underground MetalMine/TrackHighlight");
        track.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(65f, -11f, -33f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine( BackFill());
    }

    IEnumerator BackFill()
    {
        Debug.Log("BackFill");
        Material track = Resources.Load<Material>("Highlight Materials/Underground MetalMine/TrackHighlight");
        track.DisableKeyword("_EMISSION");
        Material backfill = Resources.Load<Material>("Highlight Materials/Underground MetalMine/Backfill Highlight");
        backfill.EnableKeyword("_EMISSION");
        AudioChange();
        audioSource.Play();
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(87.17f, -11f, -46.79f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(Trolley());
    }

    IEnumerator Trolley()
    {
        AudioChange();
        audioSource.Play();
       
        Debug.Log("Trolley");
        Material backfill = Resources.Load<Material>("Highlight Materials/Underground MetalMine/Backfill Highlight");
        backfill.DisableKeyword("_EMISSION");
        Material trolley = Resources.Load<Material>("Highlight Materials/Underground MetalMine/TrolleyHighlight");
        trolley.EnableKeyword("_EMISSION");
        
        yield return new WaitForSeconds(5);
        StartCoroutine(Explosive());
    }

    IEnumerator Explosive()
    {
        AudioChange();
        audioSource.Play();
        Material explore = Resources.Load<Material>("Highlight Materials/Underground MetalMine/ExploreHighlight");
        explore.EnableKeyword("_EMISSION");
        Material explore1 = Resources.Load<Material>("Highlight Materials/Underground MetalMine/ExploreDynamiteHighlight");
        explore1.EnableKeyword("_EMISSION");
        Material trolley = Resources.Load<Material>("Highlight Materials/Underground MetalMine/TrolleyHighlight");
        trolley.DisableKeyword("_EMISSION");
        Debug.Log("Explosive");
        yield return new WaitForSeconds(5);
        
        StartCoroutine(Deposit());
    }

     IEnumerator Deposit()
    {
        AudioChange();
        audioSource.Play();
        Material explore = Resources.Load<Material>("Highlight Materials/Underground MetalMine/ExploreHighlight");
        explore.DisableKeyword("_EMISSION");
        Material explore1 = Resources.Load<Material>("Highlight Materials/Underground MetalMine/ExploreDynamiteHighlight");
        explore1.DisableKeyword("_EMISSION");
        Material deposit = Resources.Load<Material>("Highlight Materials/Underground MetalMine/DepositHighlight");
        deposit.EnableKeyword("_EMISSION");

        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
        Vector3 pos = new Vector3(95, -11f, -51f);
        gameObject.transform.position = pos;
        gameObject.SetActive(true);
        StartCoroutine(Cage());
    }


    IEnumerator Cage()
    {
        AudioChange();
        audioSource.Play();
        Material deposit = Resources.Load<Material>("Highlight Materials/Underground MetalMine/DepositHighlight");
        deposit.DisableKeyword("_EMISSION");
        Material cage = Resources.Load<Material>("Highlight Materials/Underground MetalMine/CageHighlight");
        cage.EnableKeyword("_EMISSION");
        Debug.Log("Cage");
        yield return new WaitForSeconds(5);
        StartCoroutine(Closure());
    }

    IEnumerator Closure()
    {
        Material cage = Resources.Load<Material>("Highlight Materials/Underground MetalMine/CageHighlight");
        cage.DisableKeyword("_EMISSION");
        yield return new WaitForSeconds(5);
        AudioChange();
        audioSource.Play();
        MetalMineCaveFrontPos();
        MetalMineprosNconsCanvas.SetActive(true);
    }
}
