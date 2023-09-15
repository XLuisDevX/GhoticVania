using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleEffect : MonoBehaviour
{
    public TMP_Text text;
    private ParallaxEffect parallaxEffect;
    private TMP_Text uiText;
    private TMP_Text playText, optionsText, quitText;
    [SerializeField] private float fadeInTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        text.alpha = 0;
        parallaxEffect = GameObject.Find("mountains_1").GetComponent<ParallaxEffect>();
        uiText = GameObject.Find("Game Title").GetComponent<TMP_Text>();
        playText = GameObject.Find("Play Text").GetComponent<TMP_Text>();
        optionsText = GameObject.Find("Options Text").GetComponent<TMP_Text>();
        quitText = GameObject.Find("Quit Text").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parallaxEffect.getIsMoving())
        {
            // TODO: Set alpha text to 1 to create visual effect
            if(gameObject.CompareTag("Game Title"))
            {
                text.alpha += Time.deltaTime / fadeInTime;
            } else
            {
                this.showButtonText();
            }
        }
    }

    private void showButtonText()
    {
        switch(gameObject.tag)
        {
            case "Play Text":
                if (uiText.alpha >= 1) text.alpha += Time.deltaTime / fadeInTime;
                break;
            case "Options Text":
                if(playText.alpha >= 1) text.alpha += Time.deltaTime / fadeInTime;
                break;
            case "Quit Text":
                if(optionsText.alpha >= 1) text.alpha += Time.deltaTime / fadeInTime;
                break;
        }
    }
}
