using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainHandler : MonoBehaviour
{
    public Text countDownText;
    public float speed = 50.0f;
    public float accSpeed = 50.0f;
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
    //bool emptySlider;

    //Boards
    BoardsHolder boards;
    bool moveBoardY;

    //BG Images
    BgImagesHolder bgImages;

    //Slider 
    bool isFullSlider;
    SliderHandler slider;

    AccelerometerController accController = new AccelerometerController();
    public ResetButton resetButton;

    //Gyroscope Control
    RotateMouse rotatePlatform;
    private Gyroscope gyro;

    // Use this for initialization
    void Start()
    {
        levelIndex = 0;
        startGameplay = false;
        //emptySlider = false;
        moveBoardY = false;
        boards = GameObject.Find("BoardsHolder").GetComponent<BoardsHolder>();
        boards.boards[levelIndex].SetActive(true);
        bgImages = GameObject.Find("BGImagesContainer").GetComponent<BgImagesHolder>();
        bgImages.bgImages[levelIndex].SetActive(true);
        //hole = GameObject.Find("HoleHandler").GetComponent<HoleCollider>();
        //hole = boards.boards[0].GetComponentInChildren<HoleCollider>();
        aSources = GetComponents<AudioSource>();
        bgMusicList = GameObject.Find("BGMusic").GetComponents<AudioSource>();
        bgMusic = aSources[levelIndex];
        bgMusic0 = bgMusicList[levelIndex];
        RenderSettings.ambientIntensity = 1.0f;
        countVoice3 = aSources[1];
        countVoice2 = aSources[2];
        countVoice1 = aSources[3];
        countVoiceHitIt = aSources[4];
        textGameObj = GameObject.FindGameObjectWithTag("Text");
        levelComplete = GameObject.FindGameObjectWithTag("Level Complete").GetComponent<Text>();
        levelComplete.gameObject.SetActive(false);

        //Slider
        isFullSlider = false;
        slider = new SliderHandler();
        StartCoroutine(StartCountdown());

        //Gyroscope
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        rotatePlatform = new RotateMouse();
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
        bgImages.bgImages[levelIndex].SetActive(false);
        levelIndex += 1;
        levelComplete.gameObject.SetActive(false);
        StartCoroutine(StartCountdown());
        yield break;
    }

    void InitBoard()
    {
        //boards.boards[0].SetActive(true);
        boards.boards[levelIndex].SetActive(true);
        bgImages.bgImages[levelIndex].SetActive(true);
        hole = boards.boards[levelIndex].GetComponentInChildren<HoleCollider>();
        slider.emptySlider = false;
        if (levelIndex != 0 && !resetButton.reset)
        {
            moveBoardY = true;
            Destroy(boards.boards[levelIndex - 1]);
        }
        resetButton.reset = false;
        //hole = GameObject.Find("HoleHandler").GetComponent<HoleCollider>();
    }

    void NextLevel()
    {
        slider.emptySlider = true;
        levelComplete.gameObject.SetActive(true);
        bgMusicList[levelIndex].Stop();
        StartCoroutine(PrepareNextLevel(2f));
    }

    void Update()
    {
        if (startGameplay)
        {
            Debug.Log(speed);
            transform.Rotate(rotatePlatform.GetVector() * Time.deltaTime * speed);
            if (resetButton.reset)
            {
                Debug.Log(resetButton.reset);
                startGameplay = false;
                StartCoroutine(StartCountdown());
            }
            else
            {
                if (hole.onCollider1 && hole.onCollider2)
                {
                    isFullSlider = slider.FillSlider(ref hole.onCollider1, ref hole.onCollider2, ref startGameplay);
                    if (isFullSlider)
                        NextLevel();

                }
                else if (null != slider.sliderAudioRise)
                {
                    slider.sliderAudioRise.Pause();
                }
            }
        }
        if (slider.emptySlider)
        {
            slider.EmptySlider();
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
