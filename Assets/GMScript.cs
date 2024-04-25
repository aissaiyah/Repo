using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMScript : MonoBehaviour
{
    public bool Lasered = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);//makes object persist between scenes
    }



    private void Update()
    {
        Collider2D[] collisionList = Physics2D.OverlapCircleAll(transform.position, .2f);
        for (int i = 0; i < collisionList.Length; i++)
        {
            if (collisionList[i].gameObject.tag == "laser") Lasered = true;
        }
        if (GameObject.Find("CheckBox (1)").GetComponent<CheckBoxScript>().Lasered == true// if both boxes are lasered you win
        && GameObject.Find("CheckBox (2)").GetComponent<CheckBoxScript>().Lasered == true) SceneManager.LoadSceneAsync("Win");
    }
}
