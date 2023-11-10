using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{

    private static BattleHandler instance;
    public static BattleHandler GetInstance() { return instance; }

    [SerializeField] private Transform pfHeroBattle;
    [SerializeField] private Transform pfEnemyBattle;

    private CharAnimController heroAnimCon;
    private CharAnimController enemyAnimCon;
    private CharAnimController activeCharCon;

    public Slider sliderHero;
    public Slider sliderEnemy;

    private Vector3 heroesPos = new Vector3(5,0);
    private Vector3 enemiesPos = new Vector3(-5, 0);

    private State state;

    private enum State
    {
        WaitingForPlayer,
        Busy,
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        heroAnimCon = SpawnCharacter(true, pfHeroBattle);
        enemyAnimCon = SpawnCharacter(false, pfEnemyBattle);


        SetActiveCharCon(heroAnimCon);
        state = State.WaitingForPlayer;
    }

    private void Update()
    {
        sliderHero.value += 1 * Time.deltaTime/5;
        sliderEnemy.value += 1 * Time.deltaTime/5;
        if (sliderHero.value == sliderHero.maxValue)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                sliderHero.value = 0;
                state= State.Busy;
                heroAnimCon.AttackTurn(enemyAnimCon, () => { NextTurnEntity(); });
            }
        }
        if (sliderEnemy.value == sliderEnemy.maxValue)
        {
            sliderEnemy.value = 0;
            enemyAnimCon.AttackTurn(heroAnimCon, () => { NextTurnEntity(); });
        }
    }

    private CharAnimController SpawnCharacter(bool isPlayer, Transform pfEntity)
    {
        Vector3 position;
        if (isPlayer)
            position = heroesPos;
        else
            position = enemiesPos;
        Transform charTransform = Instantiate(pfEntity, position, Quaternion.identity);
        CharAnimController charAnimController = charTransform.GetComponent<CharAnimController>();
        charAnimController.Setup(isPlayer);

        return charAnimController; 
    }

    private void SetActiveCharCon(CharAnimController charAnimController)
    {
        activeCharCon = charAnimController;
    }

    private void NextTurnEntity()
    {
        
        if( sliderEnemy.value == sliderEnemy.maxValue)
        {
            sliderEnemy.value = 0;
            SetActiveCharCon(enemyAnimCon);
            state = State.Busy;
            enemyAnimCon.AttackTurn(heroAnimCon, () => { NextTurnEntity(); }); 
        }   
        else
        {
            SetActiveCharCon(heroAnimCon);
            state = State.WaitingForPlayer;
        }
    }
    
}
