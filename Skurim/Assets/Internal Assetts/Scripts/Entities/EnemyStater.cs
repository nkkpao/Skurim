using System.Collections;
using UnityEngine;

public class EnemyStater : BasicStater
{
    public BasicEnemy enemy;
    public GameObject atkTarget;

    public override void Update()
    {
        switch (curState)
        {
            case State.proc:
                upGauge(curSlider);
                break;
            case State.chsAct:
                chAct();
                curState = State.wait;
                break;
            case State.wait:
                break;
            case State.act:
                StartCoroutine(ActNumerator());
                break;
            case State.dead:
                break;
        }
    }

    void chAct()
    {
        Trurn enAtk = new Trurn();
        enAtk.Name = enemy.name;
        enAtk.thisObj = this.gameObject;
        enAtk.faction = Faction.Enemy;
        enAtk.targetObj = battleHandler.heroesObjs[Random.Range(0, battleHandler.heroesObjs.Count)];
        battleHandler.addAction(enAtk);
        slideTargetPos = enAtk.targetObj.transform.position;
    }

    protected IEnumerator ActNumerator()
    {
        if (isStarted)
        {
            yield break;
        }
        isStarted = true;


        while (MoveToPos(new Vector2(atkTarget.transform.position.x - 2, atkTarget.transform.position.y)))
        { yield return null; }

        //yield return new WaitForSeconds(0.2f);

        enemy.Attack(atkTarget.GetComponent<HeroStater>().hero);

        while (MoveToPos(startPos)) { yield return null; }

        battleHandler.performQ.Dequeue();

        battleHandler.state = BattleHandler.State.Waiting;

        isStarted = false;
        curGaugeV = 0f;
        curState = State.proc;
    }

    private bool MoveToPos(Vector3 target)
    {
        float slideSpeed = 10f;
        transform.position += (target - GetPosition()) * slideSpeed * Time.deltaTime;
        return new Vector3(target.x, target.y, 0) != (transform.position);
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
