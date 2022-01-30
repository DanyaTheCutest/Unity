using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleTextOutput : MonoBehaviour
{
    [SerializeField] private Text _screenText;
    [SerializeField] private float _speed = 17;
    [SerializeField] private bool _gameIsEnd;

    private string _startGameString;
    private string _endGameString;
    private string _outputText;

    private void OnValidate()
    {
        if (_speed <= 0)
            _speed = 0.1f;
    }

    private void OnEnable()
    {
        _startGameString = "Я — обычный фермер.\n" +
            "Не воин и не солдат.\n" +
            "Но когда вилы не помогают, в ход идёт старенький дробовик.\n" +
            "Это моя земля. Моя ферма. Моя страна.\n" +
            "Вторгшиеся твари хотят отобрать всё то, что по праву принадлежит мне и моему народу.\n" +
            "Так пусть же перед кровью они вкусят свинца.\n\n" +
            "...\n\n" +
            "Ведь я уже слышу их мерзкий рёв.";

        _endGameString = "Даже после сражения я слышал, как раненые твари мерзко кряхтели на траве.\n" +
            "И когда я добил последнюю тушу, выпустив мозги на землю...\n" +
            "Наконец всё было позади.\n" +
            "Я откинул в сторону дымящийся ствол дробовика и упал на спину, вглядываясь в небо.\n" +
            "На самом деле всё прошло не так плохо.\n" +
            "В конце-концов из этих тел выйдут неплохие удобрения.\n\n" +
            "...\n\n" +
            "Ведь я — всего лишь фермер.";

        _outputText = _gameIsEnd ? _endGameString : _startGameString;

        PrintText();
    }

    private void PrintText()
    {
        _screenText.DOText(_outputText, _speed, true).SetRelative().SetEase(Ease.Linear);
    }
}
