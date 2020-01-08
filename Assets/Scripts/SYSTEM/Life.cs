using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField]
    Text lifeText;
    [SerializeField] int value = 3;

    void Awake(){
        lifeText.text = value.ToString();
    }

    public int GetLife()
    {
        return int.Parse(lifeText.text);
    }

    public void SetLife(int value){
        Debug.Log("value" + value);
        this.value = value;
        SetLifeStr(this.value.ToString());
    }

    private void SetLifeStr(string lifeString)
    {
        lifeText.text = lifeString;
    }
}
