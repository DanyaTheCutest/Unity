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
        _startGameString = "� � ������� ������.\n" +
            "�� ���� � �� ������.\n" +
            "�� ����� ���� �� ��������, � ��� ��� ���������� ��������.\n" +
            "��� ��� �����. ��� �����. ��� ������.\n" +
            "���������� ����� ����� �������� �� ��, ��� �� ����� ����������� ��� � ����� ������.\n" +
            "��� ����� �� ����� ������ ��� ������ ������.\n\n" +
            "...\n\n" +
            "���� � ��� ����� �� ������� ��.";

        _endGameString = "���� ����� �������� � ������, ��� ������� ����� ������ �������� �� �����.\n" +
            "� ����� � ����� ��������� ����, �������� ����� �� �����...\n" +
            "������� �� ���� ������.\n" +
            "� ������� � ������� ��������� ����� ��������� � ���� �� �����, ����������� � ����.\n" +
            "�� ����� ���� �� ������ �� ��� �����.\n" +
            "� �����-������ �� ���� ��� ������ �������� ���������.\n\n" +
            "...\n\n" +
            "���� � � ����� ���� ������.";

        _outputText = _gameIsEnd ? _endGameString : _startGameString;

        PrintText();
    }

    private void PrintText()
    {
        _screenText.DOText(_outputText, _speed, true).SetRelative().SetEase(Ease.Linear);
    }
}
