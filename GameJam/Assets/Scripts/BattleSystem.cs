using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}
public class BattleSystem : MonoBehaviour
{

    public GameObject PlayerPre;
    public GameObject EnemyPre;
    public Text Text;

    public Transform PlayerBattleS;
    public Transform EnemyBattleS;

    EnemyBattle PlayerUnit;
    EnemyBattle EnemyUnit;

    public BattleHUD PLayerH;
    public BattleHUD EnemyH;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        Setup();
    }

    void Setup()
    {
       GameObject PlayerTime = Instantiate(PlayerPre, PlayerBattleS);
        PlayerUnit = PlayerTime.GetComponent<EnemyBattle>();

       GameObject EnemyTime = Instantiate(EnemyPre, EnemyBattleS);
        EnemyUnit = EnemyTime.GetComponent<EnemyBattle>();

        Text.text = "A" + " " + EnemyUnit.Unitname + "\n" + "Wants to Fight";

        PLayerH.SetHUD(PlayerUnit);
        PLayerH.SetHUD(EnemyUnit);
    }
}
