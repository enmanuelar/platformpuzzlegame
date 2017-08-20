using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderHandler : MonoBehaviour
{
    //Slider 
    public bool playSound;
    GameObject sliderObj;
    public AudioSource[] sliderAudio;
    public AudioSource sliderAudioComplete;
    public AudioSource sliderAudioRise;
    public bool emptySlider;
    Slider slider;

    // Use this for initialization
    public SliderHandler ()
    {
        playSound = false;
        emptySlider = false;
        sliderObj = GameObject.FindGameObjectWithTag("Slider");
        slider = sliderObj.GetComponent<Slider>();
        sliderAudio = sliderObj.GetComponents<AudioSource>();
        sliderAudioComplete = sliderAudio[0];
        sliderAudioRise = sliderAudio[1];
    }

    public bool FillSlider(ref bool holeCollider1, ref bool holeCollider2, ref bool startGameplay)
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
            holeCollider1 = false;
            holeCollider2 = false;
            return true;
        }
        return false;
    }

    public void EmptySlider()
    {
        slider.value -= Time.deltaTime * 0.5f;
    }
}
