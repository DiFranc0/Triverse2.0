using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddXP : MonoBehaviour
{
    protected MMProgressBar _progressBar;
    protected float _points;
    protected float minValue = 0f;
    protected float maxValue = 100f;
    protected bool _lvl1Active = false;
    protected bool _lvl2Active = false;
    protected bool _lvl3Active = false;
    public TMP_Text _xpText;
    public TMP_Text _lvlText;
    public GameObject upgradeScreen;
    // Start is called before the first frame update
    

    protected virtual void Start()
    {
        Initialization();
        GameManager.Instance.Points = 0;
        minValue = 0f;
        maxValue = 100f;
        _lvl1Active = false;
        _lvl2Active = false;
        _lvl3Active = false;
}

    protected virtual void Initialization()
    {
        _progressBar = GetComponent<MMProgressBar>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _xpText.text = "XP " + _points.ToString();
        _points = GameManager.Instance.Points;
        _progressBar.UpdateBar(_points, minValue, maxValue);

        if(_points == 100f)
        {
            minValue = 100f;
            maxValue = 300f;
        }

        if(_points == 300f)
        {
            minValue = 300f;
            maxValue = 1000f;
        }

        UpdateLVL(_points);
    }


    void UpdateLVL(float xp)
    {
        if (xp == 100 && _lvl1Active == false)
        {
            Time.timeScale = 0;
            _lvlText.text = "LVL 1 /";
            upgradeScreen.SetActive(true);
            _lvl1Active = true;
        }

        if(xp == 300f && _lvl2Active == false)
        {
            Time.timeScale = 0;
            _lvlText.text = "LVL 2 /";
            upgradeScreen.SetActive(true);
            _lvl2Active = true;
        }

        if(xp == 1000f && _lvl3Active == false)
        {
            Time.timeScale = 0;
            _lvlText.text = "LVL 3 /";
            upgradeScreen.SetActive(true);
            _lvl3Active = true;
        }
    }
}
