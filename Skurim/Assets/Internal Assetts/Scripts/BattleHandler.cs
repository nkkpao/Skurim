using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    public enum State
    {
        Waiting,
        Acting,
        Performing
    }
    public State state;

    private static BattleHandler instance;
    public static BattleHandler GetInstance() { return instance; }

    public ScriptableObjectEntitiesPack heroesPack;
    public ScriptableObjectEntitiesPack enemiesPack;

    //??    

    public Queue<Trurn> performQ = new Queue<Trurn>();
    public List<GameObject> heroesObjs = new List<GameObject>();
    public List<List<UnityEngine.UI.Slider>> slidersHeroes = new List<List<UnityEngine.UI.Slider>>();
    public List<GameObject> enemiesObjs = new List<GameObject>();

    bool actionTaken = false;

    public GridManager grid;


    private Vector3 heroesPos;
    private Vector3 enemiesPos;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        heroesPos = grid.GetTile(148).transform.position;
        enemiesPos = grid.GetTile(49).transform.position;

        slidersHeroes = spawnUI(heroesPack, new Vector2(7.31f, -3.41f), new Vector2(7.31f, -6.93f));
        enemiesObjs = InitEnemies(enemiesPack, 4, enemiesPos);
        heroesObjs = InitHeroes(heroesPack, heroesPos);

        for (int i = 0; i < slidersHeroes.Count; i++)
        {
            slidersHeroes[i][0].maxValue = heroesObjs[i].GetComponent<HeroStater>().hero.MaxHp;
        }

        state = State.Waiting;
    }

    public List<GameObject> InitEnemies(ScriptableObjectEntitiesPack pack, int count, Vector3 pos)
    {
        List<GameObject> entities = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            GameObject charObj = Instantiate(pack.entities[Random.Range(0, pack.entities.Count)].entityPrefab, pos + new Vector3(0, i * 2 - 2, 0), Quaternion.identity);
            BasicEnemy enemy = charObj.transform.GetComponent<EnemyStater>().enemy;
            enemy.name = "enemy" + i.ToString();
            charObj.name = enemy.name;
            enemy.init();
            entities.Add(charObj);
        }
        return entities;
    }

    public List<GameObject> InitHeroes(ScriptableObjectEntitiesPack pack, Vector3 pos)
    {
        List<GameObject> entities = new List<GameObject>();
        for (int i = 0; i < 4; i++)
        {
            if (pack.entities[i] != null)
            {
                GameObject charObj = Instantiate(pack.entities[i].entityPrefab, pos + new Vector3(0, i * 2 - 2, 0), Quaternion.identity);
                BasicHero hero = charObj.transform.GetComponent<HeroStater>().hero;
                charObj.transform.GetComponent<HeroStater>().curSlider = slidersHeroes[i][1];
                hero.name = "hero" + i.ToString();
                charObj.name = hero.name;
                hero.init();
                entities.Add(charObj);
            }
        }
        return entities;
    }

    public List<List<UnityEngine.UI.Slider>> spawnUI(ScriptableObjectEntitiesPack pack, Vector3 hpBarPos, Vector3 gaugeBarPos)
    {
        List<List<UnityEngine.UI.Slider>> sliders = new List<List<UnityEngine.UI.Slider>>();
        for (int i = 0; i < 4; i++)
        {
            if (pack.entities[i] != null)
            {
                //new Vector2(7.31f, -2.41f - i)
                GameObject hpSliderObj = GameObject.Instantiate(pack.entities[i].hpGaugePF, hpBarPos + new Vector3(0, i, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
                UnityEngine.UI.Slider hpSlider = hpSliderObj.GetComponent<UnityEngine.UI.Slider>();
                // new Vector2(7.31f, -2.93f - i)
                GameObject ATBSliderObj = GameObject.Instantiate(pack.entities[i].ATBGaugePF, gaugeBarPos + new Vector3(0, 4 - i, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
                UnityEngine.UI.Slider ATBSlider = ATBSliderObj.GetComponent<UnityEngine.UI.Slider>();
                // new Vector2(4.28f, -2.67f - i)
                //GameObject attackBtn = Instantiate(attackBtnPf, buttonPos, Quaternion.identity, GameObject.Find("Canvas").transform);
                sliders.Add(new List<UnityEngine.UI.Slider> { hpSlider, ATBSlider });
            }
        }
        return sliders;
    }

    private void FixedUpdate()
    {
        //print(Time.time);
        /*if ((float)Time.time % 2 == 0)
        {
            for (int i = 0; i < heroesPack.entities.Count; i++)
            {
                if (states[i] == State.Waiting)
                    slidersHeroes[i][1].value += 2;
            }
            for (int i = 0; i < enemiesPack.entities.Count; i++)
            {
                if (states[heroesPack.entities.Count + i] == State.Waiting)
                    slidersEnemies[i][1].value += 2;
            }
        }*/
        //sliderHero.value += 1 * Time.deltaTime/5;
        //sliderEnemy.value += 1 * Time.deltaTime/5;
    }

    private void Update()
    {
        for (int i = 0; i < slidersHeroes.Count; i++)
        {
            slidersHeroes[i][0].value = heroesObjs[i].GetComponent<HeroStater>().hero.CurHp;
        }
        switch (state)
        {
            case State.Waiting:
                if (performQ.Count > 0)
                {
                    state = State.Acting;
                }
                break;
            case State.Acting:
                if (performQ.Peek().faction == Faction.Enemy)
                {
                    EnemyStater es = GameObject.Find(performQ.Peek().Name).GetComponent<EnemyStater>();
                    es.atkTarget = performQ.Peek().targetObj;
                    es.curState = EnemyStater.State.act;
                }
                if (performQ.Peek().faction == Faction.Hero)
                {

                }
                state = State.Performing;
                break;
            case State.Performing:
                break;
        }

    }

    public void PlayerAttack()
    {
        /*if (sliderHero.value == sliderHero.maxValue & state == State.Waiting)
        {
            actionTaken = true;
            state = State.Busy;
            {
                sliderHero.value = 0;
                //state = State.Busy;
                heroAnimCon.AttackTurn(enemyAnimCon, heroesPos, () => { basicHero.Attack(testEnemy); });

            }
            actionTaken = false;
            state = State.Waiting;
        }*/
    }

    public void addAction(Trurn act)
    {
        performQ.Enqueue(act);
    }

}
