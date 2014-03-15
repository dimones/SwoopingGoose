using UnityEngine;
using System.Collections;

public class SGGooseController1 : MonoBehaviour
{

    private GameObject _goose;
    private Rigidbody2D _body;
    private bool firstbool = false;
    //GenerateLevel1 _gen;
    public string _curStage = "game";
    private GUIText _obj;
    public GameObject _testObj;
    int i = 0;
    float _move;
    bool rightwall = false;

    wallAction _action;
    System.Random _rand = new System.Random();
    Transform _transWall;
}
	/*void Start () 
    {
        _transWall = GameObject.FindGameObjectWithTag("rightWall").transform;
        _action = GameObject.FindGameObjectWithTag("rightWall").GetComponent<wallAction>();
        _goose = GameObject.FindGameObjectWithTag("Player");
        _body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        _body.isKinematic = true;
        //_obj = GameObject.Find("TapToStartText").GetComponent<GUIText>();
      //  _gen.Generate();
	}

    void Update()
    {
        if(_action._enter!=true){
            
            _move += (float)Time.deltaTime * 8.5f;
            _body.transform.localPosition = new Vector2(_move, _body.transform.position.y);

        }
        else
        {
            _move -= (float)Time.deltaTime * 8.5f;
            _body.transform.localPosition = new Vector2(_move, _body.transform.position.y);
        }
       
       if(Input.touchCount > 0)
       if (Input.GetTouch(0).phase == TouchPhase.Began)
       {
          // _obj.active = false;
           _body.isKinematic = false;
           if (firstbool == false)
           {
               _body.AddForce(Vector2.up * SGGlobals._curSecond);
           }
           else _body.AddForce(Vector2.up * (SGGlobals._curSecond + SGGlobals._curfirst * 2));

           firstbool = true;
       }
    }
    
	void FixedUpdate () 
    {
        if ((Input.GetButton("Fire1")))
        {
            if (_curStage == "start")
            {
               // _obj.active = false;
            }

            _body.isKinematic = false;
            if (firstbool == false)
            {
                _body.AddForce(Vector2.up * SGGlobals._curSecond);
            }
            else _body.AddForce(Vector2.up * (SGGlobals._curSecond+SGGlobals._curfirst*2));

            firstbool = true;
        }        
	}

    void OnTriggerEnter2D(Collider2D CO)
    {
        _curStage = "lose";
    }

    void OnGUI()
        {
            if(_curStage == "game")
            {
                InGame();
                /*
                if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 400, 400), "GEN"))
                {
                    Gen();
                }
               // _gen.Generate();
            }
            else if(_curStage == "lose")
            {
                Lose();
            }
            else if(_curStage == "start")
            {
            
                StartLevel();
            }
        }

    void Gen(int j)
        {
            //GameObject _obj = (GameObject)Instantiate(_testObj, GetPos(j), Quaternion.identity);
        }

    private void StartLevel()
        {
       
            //_body.transform.position = new Vector2(-1f, 0);
           // _obj.guiText.text = "TAP TO START";
            _body.isKinematic = true;
           // _obj.active = true;
            
               

        }

    private void InGame()
        {
            if (i == 0)
                for (int j = 1; j < 100; )
                {                   
                    Gen(j);
                    j +=5;
                    print(j.ToString());
                }
            i++;
        }

    private void Lose(){
            
        _body.isKinematic = true;
           // _obj.active = true;
           // _obj.guiText.text = "YOU LOSE";
            if(GUI.Button(new Rect(Screen.width/2-150,Screen.height/2,150,150),"RETRY"))
            {
                _curStage = "start";
                i = 1;
                
            }
            if (GUI.Button(new Rect(Screen.width / 2 , Screen.height / 2, 150, 150), "EXIT"))
            {
                //StartLevel();
            }
    }

    private Vector2 GetPos(int j)
        {
            int random = _rand.Next(1, 9);//y
            int random1 = j;//x
            float _fl1 = (float)random;//x
            float _fl11 = (float)_rand.NextDouble() * random1;//y
            float _fl2 = 10 - _fl1 - _rand.Next(1, 15);//
            print((new Vector2(_fl11, _fl1)).ToString());
            return new Vector2(_fl11, _fl1);
        }
}
*/