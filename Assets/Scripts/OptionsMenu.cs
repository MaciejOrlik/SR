using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
using System.Linq;


public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public TMPro.TMP_Dropdown dropDownRes;
    public AudioMixer audioMixer;
    public TextMeshProUGUI graph;
    public Slider volSlider;
    public Toggle FCToggle;
    private int currentResolitonIndex;
    private int qualityIndex;
    private bool isFC;
    private float vol;

    OptionData optionData;

    Resolution[] resolutions;

    private static string[] quality = { "LOW", "MEDIUM", "HIGH" };

    private void Start()
    {
        resolutions = Screen.resolutions;
        dropDownRes.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option =
                resolutions[i].width + "x" +
                resolutions[i].height;
            if (i > 0)
            {
                if (resolutions[i].width != resolutions[i - 1].width &&
                    resolutions[i - 1].height != resolutions[i].height)
                {
                    options.Add(option);
                }
            }
            else
            {
                options.Add(option);
            }
            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolitonIndex = i;
            }

        }
        options = options.Distinct().ToList();
        dropDownRes.AddOptions(options);
        Load();
        
        if (optionData.currentResolitonIndex != -1)
        {
            currentResolitonIndex = optionData.currentResolitonIndex;
        }
        dropDownRes.value = currentResolitonIndex;

        dropDownRes.RefreshShownValue();

        SetFC(isFC);
        SetVolume(vol);
        SetSlider();
        SetQuality(qualityIndex);
        SetResolution(currentResolitonIndex);

    }

    public void Save()
    {
        optionData.currentResolitonIndex = currentResolitonIndex;
        optionData.qualityIndex = qualityIndex;
        optionData.isFC = isFC;
        optionData.vol = vol;
        OptionSave.OpSave(optionData);
    }

    public void Load()
    {
        optionData = OptionSave.OpLoad();
        qualityIndex =optionData.qualityIndex;
        isFC=optionData.isFC;
        vol=optionData.vol;
    }

    public void SetVolume(float volume)
    {
        vol = volume;
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetSlider()
    {
        float value;
        bool result = audioMixer.GetFloat("Volume", out value);
        if (result)
        {
            volSlider.value = value;
        }
        else volSlider.value = 0;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        graph.text = quality[qualityIndex];
    }

    public void SetFC (bool isFC)
    {
        FCToggle.isOn = isFC;
        SetFullscreen(isFC);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        isFC = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        currentResolitonIndex = resolutionIndex;
        string res = dropDownRes.options[dropDownRes.value].text;
        string rw = res.Substring(0, res.IndexOf("x"));
        string rh = res.Substring(res.IndexOf("x") + 1, res.Length - res.IndexOf("x") - 1);
        Screen.SetResolution(int.Parse(rw), int.Parse(rh), Screen.fullScreen);
    }

    public void PlayGame()
    {
        Save();
        SceneManager.LoadScene("Tor_01");
    }

    public void Options()
    {
        if (optionsMenu.activeSelf)
        {
            optionsMenu.SetActive(false);
        }
        else
        {
            optionsMenu.SetActive(true);
        }
        Save();
    }
    public void QuitGame()
    {
        Save();
        Application.Quit();
    }

    public void Back()
    {
        Save();
        optionsMenu.SetActive(false);
    }
    public void IncQual()
    {
        if (qualityIndex < 2)
        {
            qualityIndex++;
        }
        else
        {
            qualityIndex = 0;
        }
        SetQuality(qualityIndex);
    }

    public void DecQual()
    {
        if (qualityIndex == 0)
        {
            qualityIndex = 2;
        }
        else
        {
            qualityIndex--;
        }
        SetQuality(qualityIndex);
    }
}
