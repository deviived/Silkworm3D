using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{

    [SerializeField] Transform m_StartPos;
    [SerializeField] Transform m_EndPos;

    delegate float EasingDelegate(float k);

    IEnumerator m_BackForthCoroutine;

    void LOG(string msg)
    {
        Debug.Log(Time.frameCount + "-" + this.GetType() + "-" + msg);
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //StartCoroutine(MyCoroutine(3f));
        yield return new WaitForSeconds(.5f);
        //StartCoroutine(TranslateCoroutine(1f, m_StartPos.position, m_EndPos.position, Easing.Circular.Out, methodBidon));
        /*StartCoroutine(TranslateCoroutine(1f, m_StartPos.position, m_EndPos.position, Easing.Circular.Out, () => {
            Debug.Log("autre method bidon");
        }));*/

        //StartCoroutine(BackAndForthCoroutine(1f, 2f, m_StartPos.position, m_EndPos.position));
        m_BackForthCoroutine = BackAndForthCoroutine(1f, 2f, m_StartPos.position, m_EndPos.position);
        StartCoroutine(m_BackForthCoroutine);
    }

    void methodBidon()
    {
        LOG("METHOD BIDON");
    }

    IEnumerator MyCoroutine(float duration)
    {
        LOG("Start myCoroutine");
        //yield return new WaitForSeconds(duration);
        //yield return null;
        //yield return new WaitForEndOfFrame();

        float elapsedTime = 0;
        while(elapsedTime < duration)
        {
            LOG("MyCoroutine");
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        LOG("End myCoroutine");
        yield break;
    }

    IEnumerator TranslateCoroutine(float duration, Vector3 startPos, Vector3 endPos, EasingDelegate easingFunc, Action endAction)
    {
        float elapsedTime = 0;

        while(elapsedTime < duration)
        {
            float k = elapsedTime / duration;
            //transform.position = Vector3.Lerp(startPos, endPos, Mathf.Sin(k*Mathf.PI*.5f));
            //transform.position = Vector3.Lerp(startPos, endPos, 1-Mathf.Pow(k, 4));
            //transform.position = Vector3.Lerp(startPos, endPos, 1-Mathf.Pow(k-1, 2));
            transform.position = Vector3.Lerp(startPos, endPos, easingFunc(k));

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;

        if (endAction != null) endAction();
        //StartCoroutine(TranslateCoroutine(duration, endPos, startPos));
    }

    IEnumerator BackAndForthCoroutine(float forthDuration, float backDuration, Vector3 startPos, Vector3 endPos)
    {
        yield return StartCoroutine(TranslateCoroutine(forthDuration, startPos, endPos, Easing.Bounce.In, null));
        yield return StartCoroutine(TranslateCoroutine(backDuration, endPos, startPos, Easing.Cubic.Out, null));
        //StartCoroutine(BackAndForthCoroutine(1f, 2f, startPos, endPos));
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 40), "STOP COROUTINE"))
        {
            StopCoroutine(m_BackForthCoroutine);
            m_BackForthCoroutine = null;
        }
    }

    void Update()
    {
        //LOG("UPDATE");

        //transform.position = Vector3.Lerp(m_StartPos.position, m_EndPos.position, Mathf.PingPong(Time.time * 2, 1));
    }
    void FixedUpdate()
    {
        //LOG("fixedUPDATE");
    }
    void LateUpdate()
    {
        //LOG("lateUPDATE");
    }
}
