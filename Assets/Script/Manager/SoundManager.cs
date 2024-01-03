using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //public GameObject SettingPanel;

    public AudioClip[] audio_Clips;
    private AudioSource bgm_Player;
    private AudioSource sfx_Player;

    public Slider bgm_Slider;
    public Slider sfx_Slider;

    public static SoundManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }


        bgm_Player = GameObject.Find("BGM_Player").GetComponent<AudioSource>();
        sfx_Player = GameObject.Find("SFX_Player").GetComponent<AudioSource>();



        if (!PlayerPrefs.HasKey("BGM_Volume"))
        {
            PlayerPrefs.SetFloat("BGM_Volume", 1f);
        }
        if (!PlayerPrefs.HasKey("SFX_Volume"))
        {
            PlayerPrefs.SetFloat("SFX_Volume", 1f);
        }
    }

    void Start()
    {
        bgm_Slider.value = PlayerPrefs.GetFloat("BGM_Volume");
        sfx_Slider.value = PlayerPrefs.GetFloat("SFX_Volume");
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameStart")
        {
            GameObject.Find("Setting").transform.GetChild(0).gameObject.SetActive(true);
            bgm_Slider = GameObject.Find("BGM_Slider").GetComponent<Slider>();
            sfx_Slider = GameObject.Find("Sound_Effect_Slider").GetComponent<Slider>();

            bgm_Slider.onValueChanged.AddListener(ChangeBgmSound);
            sfx_Slider.onValueChanged.AddListener(ChangeSfxSound);

            GameObject.Find("Setting").transform.GetChild(0).gameObject.SetActive(false);
        }
        if (scene.name == "GamePlay")
        {
            bgm_Player.volume = PlayerPrefs.GetFloat("BGM_Volume");
            sfx_Player.volume = PlayerPrefs.GetFloat("SFX_Volume");
        }
    }
    public void PlaySound(string type)
    {
        int index = 0;

        switch (type)
        {
            case "Touch": index = 0; break;
            case "Item_Eat": index = 1; break;
            case "FlowerBoom": index = 2; break;
            case "Leaf": index = 3; break;
            case "FlowerGuard": index = 4; break;
            case "BeePlane": index = 5; break;
            case "MiniBug": index = 6; break;
            case "GameOver": index = 7; break;
        }

        sfx_Player.clip = audio_Clips[index];
        sfx_Player.Play();
    }

    public void ChangeBgmSound(float value)
    {
        PlayerPrefs.SetFloat("BGM_Volume", value);
    }

    public void ChangeSfxSound(float value)
    {
        PlayerPrefs.SetFloat("SFX_Volume", value);
    }
}
