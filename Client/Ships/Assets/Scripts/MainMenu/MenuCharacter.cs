using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCharacter : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _fraction;
    [SerializeField] private GameObject _pirate;
    [SerializeField] private GameObject _corsair;
    [SerializeField] private TMP_Dropdown _piratsClans;
    [SerializeField] private TMP_Dropdown _corsairsClans;
    [SerializeField] private TMP_InputField _login;

    [SerializeField] private SkinnedMeshRenderer _pirateModel;
    [SerializeField] private SkinnedMeshRenderer _corsairModel;
    [SerializeField] private Material _blackLagoon;
    [SerializeField] private Material _funnyRoger;
    [SerializeField] private Material _british;
    [SerializeField] private Material _spanish;

    public Action<int, int> ClanChanged;
    
    private void Start()
    {
        ChangeFraction();
    }

    public void ChangeFraction()
    {
        bool isPirate = _fraction.value == 0;
        
        _corsair.SetActive(!isPirate);
        _corsairsClans.gameObject.SetActive(!isPirate);
        _pirate.SetActive(isPirate);
        _piratsClans.gameObject.SetActive(isPirate);
        
        UpdateModel(isPirate ? _pirateModel : _corsairModel, isPirate ? _piratsClans.value : _corsairsClans.value, isPirate);
    }

    private void UpdateModel(SkinnedMeshRenderer _characterModel, int clan, bool isPirate)
    {
        _characterModel.material = GetMaterial(isPirate, clan);
        ClanChanged?.Invoke(_fraction.value, clan);
    }
    
    private Material GetMaterial(bool isPirate, int clan)
    {
        if (isPirate)
            return clan == 0 ? _blackLagoon : _funnyRoger;
        
        return clan == 0 ? _british : _spanish;
    }

    public void ChangeClan(int fraction)
    {
        if (fraction == 0)
        {
            _pirateModel.material = _piratsClans.value == 0 ? _blackLagoon : _funnyRoger;
            ClanChanged?.Invoke(_fraction.value, _piratsClans.value);
        }
        else
        {
            _corsairModel.material = _corsairsClans.value == 0 ? _british : _spanish;
            ClanChanged?.Invoke(_fraction.value, _corsairsClans.value);
        }
    }
    
    public void InputLogin(string login) => PlayerSettings.Instance.SetLogin(login);

    public void StartGame()
    {
        if (string.IsNullOrEmpty(PlayerSettings.Instance.Login)) return;
        
        Fraction fraction = _fraction.value == 0 ? Fraction.Pirate : Fraction.Corsair;
        PlayerSettings.Instance.SetFraction(fraction);

        Clan clan;
        if (fraction == Fraction.Pirate)
            clan = _piratsClans.value == 0 ? Clan.BlackLagoon : Clan.FunnyRoger;
        else
            clan = _corsairsClans.value == 0 ? Clan.British : Clan.Spanish;
        PlayerSettings.Instance.SetClan(clan);

        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
