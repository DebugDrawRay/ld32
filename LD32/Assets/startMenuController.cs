using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class startMenuController : MonoBehaviour 
{
    public Image bldg;
    public Image logo;
    public Image fade;
    public Text start;

    public float revealSpeed;
    public float startRevealSpeed;

    public string level;
    private float logoRot;
    private float bldgRot;

    private bool fadeButton;

    private const float SHOW_ROT = 0;
    private const float HIDE_ROT = 90;

    private float timer;
    private bool timerSet;

    private float timer2;
    private bool timerSet2;
    void Awake()
    {
        bldg.CrossFadeAlpha(0, 0, true);
        start.CrossFadeAlpha(0, 0, true);
        fade.CrossFadeAlpha(0, 0, true);
    }
    void Start()
    {
        bldg.rectTransform.localRotation = Quaternion.AngleAxis(SHOW_ROT, Vector3.up);
        bldgRot = SHOW_ROT;
        logo.rectTransform.localRotation = Quaternion.AngleAxis(HIDE_ROT, Vector3.up);
        logoRot = HIDE_ROT;

        bldg.CrossFadeAlpha(1, startRevealSpeed, false);
        start.CrossFadeAlpha(1, startRevealSpeed, false);
    }

    void Update()
    {
        Quaternion bldgStart = bldg.rectTransform.localRotation;
        Quaternion bldgTar = Quaternion.AngleAxis(bldgRot, Vector3.up);
        bldg.rectTransform.localRotation = Quaternion.Slerp(bldgStart, bldgTar, revealSpeed);

        if (bldgStart.eulerAngles.y >= 89.5)
        {
            Quaternion logoStart = logo.rectTransform.localRotation;
            Quaternion logoTar = Quaternion.AngleAxis(logoRot, Vector3.up);
            logo.rectTransform.localRotation = Quaternion.Slerp(logoStart, logoTar, revealSpeed);
            if(logoStart.eulerAngles.y <= 1 && !timerSet)
            {
                timer = 1.5f;
                timerSet = true;
            }
        }

        if(fadeButton)
        {
            start.CrossFadeAlpha(0, revealSpeed, false);
        }

        if(timerSet)
        {
            timer -= Time.deltaTime;
            if(timer <= 0 && !timerSet2)
            {
                timer2 = 1.5f;
                timerSet2 = true;
                fade.CrossFadeAlpha(1, startRevealSpeed, false);
            }
        }

        if(timerSet2)
        {
            timer2 -= Time.deltaTime;
            if (timer2 <= 0)
            {
                Application.LoadLevel(level);
            }
        }

    }

    public void showLogo()
    {
        logoRot = SHOW_ROT;
        bldgRot = HIDE_ROT;
        fadeButton = true;
    }
}
