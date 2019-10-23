using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float _playerHealth;

    [SerializeField]
    private Image _hpBar;
    [SerializeField]
    private Text _hpText;
    [SerializeField]
    private float _barSpeed;

    public GameObject playerAnimator;
    private Animator _anim;

    private float _fillamount;

    private int _maxPlayerHealth = 100;
    private int _minPlayerHealth = 0;

    private float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    void Start()
    {
        _playerHealth = _maxPlayerHealth;
        UpdateHealth(_playerHealth);
        _anim = playerAnimator.GetComponent<Animator>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    DecreaseHealth(10);
        //}

        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    IncreaseHealth(10);
        //}

        if (Input.GetKeyDown(KeyCode.C))
        {
            ResetHealth();
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (_playerHealth - amount < _minPlayerHealth)
        {
            _playerHealth = _minPlayerHealth;
            UpdateHealth(_minPlayerHealth);
        }
        else
        {
            UpdateHealth(_playerHealth -= amount);
        }
    }

    public void IncreaseHealth(int amount)
    {
        if (_playerHealth + amount > _maxPlayerHealth)
        {
            _playerHealth = _maxPlayerHealth;
            UpdateHealth(_maxPlayerHealth);
        }
        else
        {
            UpdateHealth(_playerHealth += amount);
        }
    }

    public void ResetHealth()
    {
        _playerHealth = _maxPlayerHealth;
        UpdateHealth(_maxPlayerHealth);
    }

    public void UpdateHealth(float newPlayerHealth)
    {
        float _fillRatio = _barSpeed * Time.deltaTime;
        float _currentXValue = _playerHealth;
        float _newXValue = map(_currentXValue, 0, _maxPlayerHealth, 0, 1);

        if (newPlayerHealth != _hpBar.fillAmount)
        {
            _hpBar.fillAmount = map(_currentXValue, 0, _maxPlayerHealth, 0, 1);
            _playerHealth = newPlayerHealth;
            _hpText.text = newPlayerHealth * 100 / _maxPlayerHealth + "%";

        }

        _playerHealth = newPlayerHealth;

        if (System.Math.Abs(_hpBar.fillAmount) < 0.1f)
        {
            OnHPEmpty();
        }
        Debug.Log("newhealth: " + newPlayerHealth);
        Debug.Log("healthbarstatus: " + _hpBar.fillAmount);
    }

    private void OnHPEmpty()
    {
        _anim.Play("Player_Death");

        BroadcastMessage("OnDeath");
    }
}