using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    private float _points;
    public TMP_Text gameOverTxt;
    public static int highscore;

    // Start is called before the first frame update
    void Start()
    {
        _points = GameManager.Instance.Points;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverTxt.text = _points.ToString();
    }

    public void SaveHighscore()
    {
        highscore = (int)_points;
    }
}
