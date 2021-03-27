using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameControllerScripts
{
    public class BalanceManager : MonoBehaviour
    {
        [SerializeField] private Text balanceLabel;
        [SerializeField] private AudioClip moneySound;

        private int _totalMoney;

        public int TotalMoney
        {
            get => _totalMoney;
            set
            {
                if (value > _totalMoney)
                {
                    SoundManager.PlaySound(moneySound, transform.position);
                    StartCoroutine(ScoreFade(_totalMoney, value - _totalMoney));
                    _totalMoney = value;

                    if (SettingsManager.CurrentBalance != value)
                    {
                        SettingsManager.CurrentBalance = value;
                    }
                }
            }
        }

        private IEnumerator ScoreFade(int oldScore, int deltaScore)
        {
            var acceleration = 20.0 * deltaScore * deltaScore;
            var k = Math.Log(1 + acceleration);

            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                var tmpScore = Math.Log(1 + acceleration * i) * deltaScore / k;
                balanceLabel.text = $"$ {oldScore + (int) tmpScore}";
                yield return null;
            }

            balanceLabel.text = $"$ {oldScore + deltaScore}";
        }

        private void Start()
        {
            _totalMoney = SettingsManager.CurrentBalance;
            balanceLabel.text = $"$ {_totalMoney}";
        }
    }
}