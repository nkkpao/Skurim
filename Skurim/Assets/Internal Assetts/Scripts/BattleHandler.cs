using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{

    private static BattleHandler instance;
    public static BattleHandler GetInstance() { return instance; }

    [SerializeField] private EntityManager entityManager;
    Transform heroEntity;
    Transform enemyEntity;

    private CharAnimController heroAnimCon;
    private CharAnimController enemyAnimCon;
    private CharAnimController activeCharCon;

    public Slider sliderHero;
    public Slider sliderEnemy;

    private BasicHero basicHero;
    private TestEnemy testEnemy;
    public Slider hpSliderHero;
    public Slider hpSliderEnemy;

    public GridManager grid;

    private Vector3 heroesPos;
    private Vector3 enemiesPos;
    //11 7 // 20 7
    /*private State state;

    private enum State
    {
        WaitingForPlayer,
        Busy,
    }*/

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        heroesPos = grid.GetTileAtPosition(new Vector2(20, 7)).transform.position;
        enemiesPos = grid.GetTileAtPosition(new Vector2(11, 7)).transform.position;

        heroEntity = SpawnCharacterOnMap(true, entityManager.GetEntity("Hero1"));
        enemyEntity = SpawnCharacterOnMap(false, entityManager.GetEntity("Enemy1"));

        heroAnimCon =  heroEntity.GetComponent<CharAnimController>();
        enemyAnimCon =  enemyEntity.GetComponent<CharAnimController>();

        heroAnimCon.Setup(true);
        enemyAnimCon.Setup(false);

        basicHero = heroEntity.GetComponent<BasicHero>();
        testEnemy = enemyEntity.GetComponent<TestEnemy>();
        basicHero.init();
        testEnemy.init();

        hpSliderEnemy.maxValue = testEnemy.MaxHp;
        hpSliderHero.maxValue = basicHero.MaxHp;

        SetActiveCharCon(heroAnimCon);
        //state = State.WaitingForPlayer;
        
        
    }

    private void FixedUpdate()
    {
        //print(Time.time);
        if ((float)Time.time % 2 == 0)
        {
            sliderHero.value += 2;
            sliderEnemy.value += 2;
        }
        //sliderHero.value += 1 * Time.deltaTime/5;
        //sliderEnemy.value += 1 * Time.deltaTime/5;
    }

    private void Update()
    {

        if (sliderEnemy.value == sliderEnemy.maxValue)
        {
            sliderEnemy.value = 0;
            enemyAnimCon.AttackTurn(heroAnimCon, enemiesPos, () => { testEnemy.Attack(basicHero); NextTurnEntity(); });
            
        }
        hpSliderEnemy.value = testEnemy.CurHp;
        hpSliderHero.value = basicHero.CurHp;
    }

    private Transform SpawnCharacterOnMap(bool isPlayer, ScriptableEntity seEntity)
    {
        Vector3 position;
        if (isPlayer)
            position = heroesPos;
        else
            position = enemiesPos;
        Transform charTransform = Instantiate(seEntity.EntityPrefab.transform, position, Quaternion.identity);
        return charTransform; 
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
            //state = State.Busy;
            enemyAnimCon.AttackTurn(heroAnimCon, enemiesPos, () => { NextTurnEntity(); }); 
        }   
        else
        {
            SetActiveCharCon(heroAnimCon);
            //state = State.WaitingForPlayer;
        }
    }

    public void playerAttack()
    {
        if (sliderHero.value == sliderHero.maxValue)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            {
                sliderHero.value = 0;
                //state = State.Busy;
                heroAnimCon.AttackTurn(enemyAnimCon, heroesPos, () => { basicHero.Attack(testEnemy); NextTurnEntity(); });

            }
        }
    }

    private void battleEnd()
    {

    }
    
}
