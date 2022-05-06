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
    public GameObject musicMenu;
    public AudioMixer audioMixer;
    public TextMeshProUGUI graph;
    public Slider soundSlider;
    public Slider musicSlider;
    public Toggle FCToggle;
    private int currentResolitonIndex;
    private int qualityIndex;
    private bool isFC;
    private float vol;
    private float mus;

    OptionData optionData;

    Resolution[] resolutions;

    private static string[] quality = { "LOW", "MEDIUM", "HIGH" };


    private void Awake()
    {
        if (!musicManager.isMenuPlaying())
        {
            musicMenu.GetComponent<AudioSource>().Play();
            musicManager.DDOL(musicMenu);
        }
    }

    private void Start()
    {
        resolutions = Screen.resolutions;       // Tworzy liste dostepnych rozdzielczosci systemowych
        dropDownRes.ClearOptions();
        List<string> options = new List<string>();  // Nowa list stringow
        int blad = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option =
                resolutions[i].width + "x" +
                resolutions[i].height;  // Rozdzielczosc
            if (i > 0)                  // Czy jest wiecej niz jedno
            {
                if (resolutions[i].width != resolutions[i - 1].width &&
                    resolutions[i - 1].height != resolutions[i].height) //Sprawdza czy wczesniej nie bylo takiej rozdzielczosci (czy sie NIE powtarza)
                {
                    options.Add(option);    // Dodaje opcje
                }
                else
                {
                    blad++;     // Zwieksza sie za kazda opcje nie dodana (wykorzystywane do liczenia faktycznego indeksu)
                }
            }
            else
            {
                options.Add(option);    // Jak jest jedynym to po prostu dodaje
            }
            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height) // Czy sprawdzana rozdzielczosc jest aktualna rozdzielczoscia?
            {
                currentResolitonIndex = i-blad; // index - niedodane opcje = faktyczny index
            }

        }
        //options = options.Distinct().ToList();
        dropDownRes.AddOptions(options);        // dropDown dostaje liste rozdzielczosci
        Load();                                 // Laduje opcje z pliku (jak nie ma to default leci)
        
        if (optionData.currentResolitonIndex != -1) // Na defaulcie jest index = -1, wiec inna wartosc znaczy ze nie jest defaultem, wiec:
        {
            currentResolitonIndex = optionData.currentResolitonIndex;   // daje wczytany z pliku index jako prawdziwy
        }
        dropDownRes.value = currentResolitonIndex;  //dropDown przypisuje rozdzielczosc na podstawie indeksu
        dropDownRes.RefreshShownValue();

        //Ustaw graficznie wartosci na podstawie opcji
        SetFC(isFC);
        SetVolume(vol);
        SetMusic(mus);
        SetSlider();
        SetQuality();
        SetResolution(currentResolitonIndex);   

    }

    public void Save()  // Zapisuje dane klasy do pliku
    {
        optionData.currentResolitonIndex = currentResolitonIndex;
        optionData.qualityIndex = qualityIndex;
        optionData.isFC = isFC;
        optionData.vol = vol;
        optionData.mus = mus;
        OptionSave.OpSave(optionData);  //Zapis w pliku OptionSave.cs
    }

    public void Load()  // Zczytuje dane klasy z pliku (resolution jest zrobione w starcie)
    {
        optionData = OptionSave.OpLoad();   //Odczyt w pliku OptionSave.cs
        qualityIndex =optionData.qualityIndex;
        isFC=optionData.isFC;
        vol=optionData.vol;
        mus=optionData.mus;
    }

    public void SetVolume(float volume)
    {
        vol = volume;
        float set = (((volume + 80) / 80) * 9) + 1;
        audioMixer.SetFloat("Sound", (Mathf.Log10(set)-1)*80);
    }

    public void SetMusic(float volume)
    {
        mus = volume;
        float set = (((volume + 80) / 80) * 9) + 1;
        audioMixer.SetFloat("Music", (Mathf.Log10(set) - 1) * 80);
    }

    public void SetSlider() //Ustawia graficzna wartosc slidera
    {
        soundSlider.value = vol;
        musicSlider.value = mus;
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        graph.text = quality[qualityIndex];
    }

    public void SetFC (bool isFC) // Ustawia guzik toggla odpowiednio
    {
        FCToggle.isOn = isFC;
        SetFullscreen(isFC);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        isFC = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }

    public void SetFPSCounter (bool isFPS)
    {

    }

    public void SetResolution(int resolutionIndex) // Bierze WIDTHxHEIGHT i ustawia
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
        SceneManager.LoadScene("Garage");
    }

    public void Options()   // Wlacz/Wylacz widok opcji
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
    public void IncQual()   //qualityindex ++
    {
        if (qualityIndex < 2)
        {
            qualityIndex++;
        }
        else
        {
            qualityIndex = 0;
        }
        SetQuality();
    }

    public void DecQual()   //qualityindex --
    {
        if (qualityIndex == 0)
        {
            qualityIndex = 2;
        }
        else
        {
            qualityIndex--;
        }
        SetQuality();
    }
}
