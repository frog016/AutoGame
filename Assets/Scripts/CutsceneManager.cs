using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum CutsceneManagerState
{
    STAND_BY,
    CUTSCENE,
    GAME

}

[System.Serializable]
public class PlotInfo
{
    [SerializeField] private int _firstScene;
    [SerializeField] private int _endScene;

    public int FirstScene => _firstScene;
    public int EndScene => _endScene;
}

public class CutsceneManager : MonoBehaviour
{
    private static CutsceneManager _instance;
    public static CutsceneManager Instance => _instance;

    private int _chosenGameScene;

    public int ChosenGameScene => _chosenGameScene;

    private PlotInfo _chosenPlot;
    public PlotInfo ChosenPlot => _chosenPlot;

    [SerializeField] private List<PlotInfo> _plots;


    private void Awake() {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartPlot(int gameScene)
    {
        var randomPlotIndex = Random.Range(0, _plots.Count);
        Debug.Log(randomPlotIndex);
        _chosenPlot = _plots[randomPlotIndex];
        _chosenGameScene = gameScene;

        SceneManager.LoadScene(_chosenPlot.FirstScene);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_chosenGameScene);
    }


}
