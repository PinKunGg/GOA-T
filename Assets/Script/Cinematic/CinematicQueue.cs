using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using UnityEngine;

public class CinematicQueue : MonoBehaviour
{
    public GameObject[] Vcam;
    public GameObject EnemyCinematic;
    public GameObject[] FX;
    public CinematicTurret CT;
    public GameObject ENC;
    private void Start()
    {
        EnemyCinematic.SetActive(false);
        FX[0].SetActive(false);
        FX[1].SetActive(false);
        StartCoroutine(StartCinematic());
    }

    IEnumerator StartCinematic()
    {
        yield return new WaitForSeconds(2f);
        Vcam[0].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[1].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[2].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[3].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[4].SetActive(false);
        EnemyCinematic.SetActive(true);
        yield return new WaitForSeconds(2f);
        Vcam[5].SetActive(false);
        yield return new WaitForSeconds(0.5f);
        CT.anima.SetBool("EffectIn", true);
        yield return new WaitForSeconds(1.5f);
        CT.anima.SetBool("EffectIn", false);
        CT.anima.SetTrigger("ForceOut");
        yield return new WaitForSeconds(0f);
        CT.anima.SetBool("EffectIn", true);
        Vcam[6].SetActive(false);
        yield return new WaitForSeconds(1f);
        CT.anima.SetBool("EffectIn", false);
        CT.anima.SetTrigger("ForceOut");
        yield return new WaitForSeconds(0f);
        CT.anima.SetBool("EffectIn", true);
        Vcam[7].SetActive(false);
        yield return new WaitForSeconds(1f);
        CT.anima.SetBool("EffectIn", false);
        CT.anima.SetTrigger("ForceOut");
        yield return new WaitForSeconds(0f);
        CT.anima.SetBool("EffectIn", true);
        Vcam[8].SetActive(false);
        yield return new WaitForSeconds(1f);
        CT.anima.SetTrigger("TurnToEnemy");
        yield return new WaitForSeconds(1f);
        Vcam[9].SetActive(false);
        yield return new WaitForSeconds(1f);
        FX[0].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Vcam[10].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        Vcam[11].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[12].SetActive(false);
        yield return new WaitForSeconds(0.3f);
        FX[1].SetActive(true);
        ENC.transform.position = new Vector3(ENC.transform.position.x, -0.2f , ENC.transform.position.z);
        ENC.transform.rotation = Quaternion.Euler(90f, ENC.transform.rotation.y, ENC.transform.rotation.z);
        yield return new WaitForSeconds(5f);
        Vcam[13].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[14].SetActive(false);
        yield return new WaitForSeconds(2f);
        Vcam[15].SetActive(false);
    }
}
