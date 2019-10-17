using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int _playerHealth;

    [SerializeField]
    private Image _hpBar;
    [SerializeField]
    private float _barSpeed;

    private int _maxPlayerHealth = 100;
    private int _minPlayerHealth = 0;

    void Start()
    {
        _playerHealth = _maxPlayerHealth;
        UpdateHealth(_playerHealth);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            DecreaseHealth(10);
        }

        if (Input.GetKeyDown(KeyCode.X)) 
        {
            IncreaseHealth(10);
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            ResetHealth();
        }
    }

    public void DecreaseHealth(int amount) 
    {
        if (_playerHealth <= _minPlayerHealth) 
        {
            _playerHealth = _minPlayerHealth;
        }

        UpdateHealth(_playerHealth -= amount);
    }

    public void IncreaseHealth(int amount) 
    {
        if (_playerHealth >= _maxPlayerHealth) 
        {
            _playerHealth = _maxPlayerHealth;
        }
        
        UpdateHealth(_playerHealth += amount);
    }

    public void ResetHealth() 
    {
        _playerHealth = _maxPlayerHealth;
        UpdateHealth(_maxPlayerHealth);
    }

    public void UpdateHealth(int newPlayerHealth) 
    {
        _hpBar.fillAmount = Mathf.Lerp(_playerHealth / 100, newPlayerHealth / 100, _barSpeed * Time.deltaTime);
        _playerHealth = newPlayerHealth;
        Debug.Log("newhealth: " + newPlayerHealth);
        Debug.Log("healthbarstatus: " + _hpBar.fillAmount);
    }
}