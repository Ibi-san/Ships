using UnityEngine;

public class MenuFlagpole : MonoBehaviour
{
    [SerializeField] private GameObject _blackLagoonFlag;
    [SerializeField] private GameObject _funnyRogerFlag;
    [SerializeField] private GameObject _britishFlag;
    [SerializeField] private GameObject _spanishFlag;
    private GameObject _currentFlag;

    [SerializeField] private MenuCharacter _menuCharacter;

    private void Start()
    {
        _currentFlag = _blackLagoonFlag;
        _menuCharacter.ClanChanged += ChangeFlag;
    }

    private void ChangeFlag(int fraction, int clan)
    {
        _currentFlag.SetActive(false);
        
        if (fraction == 0)
            _currentFlag = clan == 0 ? _blackLagoonFlag : _funnyRogerFlag;
        else
            _currentFlag = clan == 0 ? _britishFlag : _spanishFlag;
        
        _currentFlag.SetActive(true);
    }
}
