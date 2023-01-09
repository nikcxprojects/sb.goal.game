using UnityEngine;

[CreateAssetMenu()]
public class FootballExpertData : ScriptableObject
{
    public QuestionData[] questionDatas;

    [System.Serializable]
    public class QuestionData
    {
        public string question;

        [Space(10)]
        public Sprite icon;

        [Space(10)]
        public string a;
        public string b;
        public string c;
        public string d;

        [Space(10)]
        public int ansverId;
    }
}
