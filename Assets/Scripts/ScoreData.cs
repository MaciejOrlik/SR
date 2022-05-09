using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{

    public string[,,] wynik;

    public ScoreData() {

        wynik = new string[,,]
        {
            {
                                     { "Melo" , "BOSSCAR", "01:55.0"}, { "Johny" , "SUPERCAR", "01:56.6"}, { "Paul" , "BOSSCAR", "01:58.8"},
                                     { "Nicki" , "SUPERCAR", "01:59.6"}, { "Karen" , "KUPRA", "02:01.1"}, { "Alex" , "KUPRA", "02:09.1"},
                                     { "James" , "TOCUS", "02:10.1"}, { "Bob" , "TOCUS", "02:41.1"}
            },
            {
                                     { "Melo" , "BOSSCAR", "01:20.0"}, { "Johny" , "SUPERCAR", "01:25.4"}, { "Paul" , "BOSSCAR", "01:28.3"},
                                     { "Nicki" , "SUPERCAR", "01:30.7"}, { "Karen" , "KUPRA", "01:32.4"}, { "Alex" , "KUPRA", "01:36.1"},
                                     { "James" , "TOCUS", "01:48.1"}, { "Bob" , "TOCUS", "02:14.0"}
            },
            {
                                     { "Melo" , "BOSSCAR", "00:45.7"}, { "Johny" , "SUPERCAR", "00:47.4"}, { "Paul" , "BOSSCAR", "00:51.6"},
                                     { "Nicki" , "SUPERCAR", "00:52.2"}, { "Karen" , "KUPRA", "00:54.2"}, { "Alex" , "KUPRA", "00:55.1"},
                                     { "James" , "TOCUS", "01:00.2"}, { "Bob" , "TOCUS", "01:09.5"}
            },
            {
                                     { "Melo" , "BOSSCAR", "00:52.9"}, { "Johny" , "SUPERCAR", "00:56.0"}, { "Paul" , "BOSSCAR", "00:58.9"},
                                     { "Nicki" , "SUPERCAR", "01:00.1"}, { "Karen" , "KUPRA", "01:03.4"}, { "Alex" , "KUPRA", "01:08.5"},
                                     { "James" , "TOCUS", "01:13.1"}, { "Bob" , "TOCUS", "01:18.0"}
            }
        };
    }
};
