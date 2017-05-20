using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainHandler : MonoBehaviour
{
    public Text countDownText;
    public float speed = 50.0f;
    public int levelIndex;
    GameObject textGameObj;
    Text levelComplete;
    AudioSource[] bgMusicList;
    AudioSource[] aSources;
    AudioSource bgMusic;
    AudioSource bgMusic0;

    AudioSource countVoice3;
    AudioSource countVoice2;
    AudioSource countVoice1;
    AudioSource countVoiceHitIt;
    public HoleCollider hole;
    bool startGameplay;
    bool emptySlider;

    //Boards
    BoardsHolder boards;
    bool moveBoardY;

    //Slider 
    bool playSound;
    GameObject sliderObj;
    AudioSource[] sliderAudio;
    AudioSource sliderAudioComplete;
    AudioSource sliderAudioRise;
    Slider slider;

    // Use this for initialization
    void Start()
    {
        levelIndex = 0;
        startGameplay = false;
        emptySlider = false;
        moveBoardY = false;
        boards = GameObject.Find("BoardsHolder").GetComponent<BoardsHolder>();
        boards.boards[0].SetActive(true);
        //hole = GameObject.Find("HoleHandler").GetComponent<HoleCollider>();
        //hole = boards.boards[0].GetComponentInChildren<HoleCollider>();
        aSources = GetComponents<AudioSource>();
        bgMusicList = GameObject.Find("BGMusic").GetComponents<AudioSource>();
        bgMusic = aSources[0];
        bgMusic0 = bgMusicList[0];

        countVoice3 = aSources[1];
        countVoice2 = aSources[2];
        countVoice1 = aSources[3];
        countVoiceHitIt = aSources[4];
        textGameObj = GameObject.FindGameObjectWithTag("Text");
        levelComplete = GameObject.FindGameObjectWithTag("Level Complete").GetComponent<Text>();
        levelComplete.gameObject.SetActive(false);
        playSound = false;
        sliderObj = GameObject.FindGameObjectWithTag("Slider");
        slider = sliderObj.GetComponent<Slider>();
        sliderAudio = sliderObj.GetComponents<AudioSource>();
        sliderAudioComplete = sliderAudio[0];
        sliderAudioRise = sliderAudio[1];
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        //boards.boards[levelIndex].SetActive(true);
        InitBoard();
        textGameObj.SetActive(true);
        countDownText.text = "3";
        countVoice3.Play();
        yield return new WaitForSeconds(1);
        countDownText.text = "2";
        countVoice2.Play();
        yield return new WaitForSeconds(1);
        countDownText.text = "1";
        countVoice1.Play();
        yield return new WaitForSeconds(1);
        countDownText.text = "HIT IT!";
        countVoiceHitIt.Play();
        try
        {
            bgMusicList[levelIndex].Play();
        }
        catch (System.IndexOutOfRangeException)
        {
            bgMusicList[0].Play();
        }
        yield return new WaitForSeconds(1);
        textGameObj.SetActive(false);
        startGameplay = true;
        yield break;
    }

    IEnumerator PrepareNextLevel(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //GameObject board = GameObject.Find("Board (1)");
        boards.boards[levelIndex].SetActive(false);
        levelIndex += 1;
        levelComplete.gameObject.SetActive(false);
        StartCoroutine(StartCountdown());
        yield break;
    }

    void InitBoard()
    {
        //boards.boards[0].SetActive(true);
        boards.boards[levelIndex].SetActive(true);
        hole = boards.boards[levelIndex].GetComponentInChildren<HoleCollider>();
        emptySlider = false;
        if (levelIndex != 0)
        {
            moveBoardY = true;
            Destroy(boards.boards[levelIndex - 1]);
        }
        //hole = GameObject.Find("HoleHandler").GetComponent<HoleCollider>();
    }

    void NextLevel()
    {
        emptySlider = true;
        levelComplete.gameObject.SetActive(true);
        bgMusicList[levelIndex].Stop();
        StartCoroutine(PrepareNextLevel(2f));
    }

    void FillSlider()
    {
        slider.value += Time.deltaTime * 0.5f;
        if (!sliderAudioRise.isPlaying)
        {
            sliderAudioRise.Play();
        }

        if (slider.value == 1.0f)
        {
            sliderAudioComplete.Play();
            startGameplay = false;
            hole.onCollider1 = false;
            hole.onCollider2 = false;
            NextLevel();
        }
    }

    void EmptySlider()
    {
        slider.value -= Time.deltaTime * 0.5f;
    }

    void Update()
    {
        //Debug.Log(hole.onCollider1 + " " + hole.onCollider2);
        if (startGameplay)
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y")) * Time.deltaTime * speed);
            if (hole.onCollider1 && hole.onCollider2)
            {
                FillSlider();
            }
            else
            {
                sliderAudioRise.Pause();
            }
        }
        if (emptySlider)
        {
            EmptySlider();
        }
        if (moveBoardY)
        {
            GameObject thisBoard = boards.boards[levelIndex];
            thisBoard.transform.Translate(Vector3.up * Time.deltaTime);
            if (thisBoard.transform.position.y >= 0)
            {
                moveBoardY = false;
            }
        }
    }
}
