using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ScoreData : MonoBehaviour
{

    public string[,,] wynik;

    public ScoreData() {

        wynik = new string[,,]
        {
            {
                                     { "Melo" , "BOSSCAR", "01:55:0"}, { "Johny" , "SUPERCAR", "01:56:6"}, { "Paul" , "BOSSCAR", "01:58:8"},
                                     { "Nicki" , "SUPERCAR", "01:59:6"}, { "Karen" , "KUPRA", "02:01:1"}, { "Alex" , "KUPRA", "02:09:1"},
                                     { "James" , "TOCUS", "02:10:1"}, { "Bob" , "TOCUS", "02:41:1"}
            },
            {
                                     { "Melo" , "BOSSCAR", "01:20:00"}, { "Johny" , "SUPERCAR", "01:25:40"}, { "Paul" , "BOSSCAR", "01:28:30"},
                                     { "Nicki" , "SUPERCAR", "01:30:70"}, { "Karen" , "KUPRA", "01:32:40"}, { "Alex" , "KUPRA", "01:36:10"},
                                     { "James" , "TOCUS", "01:48:10"}, { "Bob" , "TOCUS", "02:14:30"}
            },
            {
                                     { "Melo" , "BOSSCAR", "00:45:70"}, { "Johny" , "SUPERCAR", "00:47:40"}, { "Paul" , "BOSSCAR", "00:51:60"},
                                     { "Nicki" , "SUPERCAR", "00:52:20"}, { "Karen" , "KUPRA", "00:54:20"}, { "Alex" , "KUPRA", "00:55:10"},
                                     { "James" , "TOCUS", "01:00:20"}, { "Bob" , "TOCUS", "01:09:50"}
            },
            {
                                     { "Melo" , "BOSSCAR", "00:52:90"}, { "Johny" , "SUPERCAR", "00:56:00"}, { "Paul" , "BOSSCAR", "00:58:90"},
                                     { "Nicki" , "SUPERCAR", "01:00:10"}, { "Karen" , "KUPRA", "01:03:40"}, { "Alex" , "KUPRA", "01:08:50"},
                                     { "James" , "TOCUS", "01:13:10"}, { "Bob" , "TOCUS", "01:18:60"}
            }
        };
    }
};
