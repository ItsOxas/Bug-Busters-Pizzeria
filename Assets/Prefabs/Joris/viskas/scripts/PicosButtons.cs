using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicosButtons : MonoBehaviour
{
    public int KuriPica = 5;

    public void PirmaPica()
    {
        KuriPica = 0;
    }
    public void AntraPica()
    {
        KuriPica = 1;
    }
    public void TreciaPica()
    {
        KuriPica = 2;
    }
    public void KetvirtaPica()
    {
        KuriPica = 3;
    }

}
