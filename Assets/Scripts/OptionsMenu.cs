using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public TMPro.TMP_Dropdown dropDownRes;
    public AudioMixer audioMixer;
    public TextMeshProUGUI graph;
    public Slider volSlider;

    Resolution[] resolutions;

    private static string[] quality = { "LOW", "MEDIUM", "HIGH" };
    private static int qualityIndex = 2;

    private void Start()
    {
        resolutions = Screen.resolutions;
        dropDownRes.ClearOptions();
        List<string> options = new List<string>();

        int currentResolitonIndex = 0;

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
        dropDownRes.value = currentResolitonIndex;
        dropDownRes.RefreshShownValue();

        SetQuality(qualityIndex);

        SetSlider();
    }

    public void SetVolume(float volume)
    {
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
        Debug.Log(qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
        graph.text = quality[qualityIndex];
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        string res = dropDownRes.options[dropDownRes.value].text;
        string rw = res.Substring(0, res.IndexOf("x"));
        string rh = res.Substring(res.IndexOf("x") + 1, res.Length - res.IndexOf("x") - 1);
        Screen.SetResolution(int.Parse(rw), int.Parse(rh), Screen.fullScreen);
    }

    public void Back()
    {
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
