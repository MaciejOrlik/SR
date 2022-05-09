using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI FpsText;

    private float pollingTime = 1f;
    private float time;
    private int frameCount;
    public bool fpscount = true;

    private OptionData data;
    // Update is called once per frame
    private void Start()
    {
        data = OptionSave.OpLoad();
    }
    void Update()
    {
        if(data.isFPS == true)
        {
            time += Time.deltaTime;

            frameCount++;

            if (time >= pollingTime)
            {
                int frameRate = Mathf.RoundToInt(frameCount / time);
                FpsText.text = frameRate.ToString() + " FPS";

                time -= pollingTime;
                frameCount = 0;
            }

        }
      

    }
}
