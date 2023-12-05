using UnityEngine;
using UnityEngine.UI;

public class BasicStater : MonoBehaviour
{
    public BattleHandler battleHandler;
    public enum State
    {
        proc,
        chsAct,
        wait,
        select,
        act,
        dead
    }
    public State curState;

    protected float curGaugeV = 0f;
    protected float maxGaugeV = 5f;

    public Slider curSlider;

    protected Vector2 startPos;
    protected bool isStarted = false;
    protected Vector3 slideTargetPos;

    public virtual void Start()
    {
        battleHandler = GameObject.Find("BattleHandler").GetComponent<BattleHandler>();
        if (curSlider != null)
        {
            curSlider.maxValue = maxGaugeV;
            curSlider.value = curGaugeV;

        }
        curState = State.proc;
        startPos = transform.position;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        switch (curState)
        {
            case State.proc:
                upGauge(curSlider);
                break;
            case State.chsAct:
                break;
            case State.wait:
                break;
            case State.act:
                break;
            case State.dead:
                break;
        }
    }

    protected void upGauge(Slider slider)
    {
        slider = curSlider;
        curGaugeV = curGaugeV + Time.deltaTime;
        float calcs = Mathf.Clamp(curGaugeV, 0f, maxGaugeV);
        if (slider != null)
            slider.value = calcs;
        if (curGaugeV >= maxGaugeV)
        {
            curState = State.chsAct;
        }
    }
}
