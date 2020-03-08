using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text Nametext;
    public Text Level;
    public Slider HP;

    public void SetHUD(EnemyBattle battle)
    {
        Nametext.text = battle.Unitname;
        Level.text = "LVL:" + battle.Unitlevel;

        HP.maxValue = battle.MaxHp;
        HP.value = battle.CurrentHP;
    }


    public void HPSet(int Hp)
    {
        HP.value = Hp;

    }
}
