using UnityEngine;

[CreateAssetMenu()]
public class GuessChampionData : ScriptableObject
{
    public QuestionData[] questionDatas;

    [System.Serializable]
    public class QuestionData
    {
        public string year;
        public string hostCountry;
        

        [Space(10)]
        public string a;
        public string b;
        public string c;
        public string d;

        [Space(10)]
        public int ansverId;
    }
}
