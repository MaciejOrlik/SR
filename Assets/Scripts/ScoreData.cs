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
                                     { "Melo" , "BOSSCAR", "00:57.5"}, { "Johny" , "SUPERCAR", "00:58.4"}, { "Paul" , "BOSSCAR", "00:59.4"},
                                     { "Nicki" , "SUPERCAR", "00:59.8"}, { "Karen" , "KUPRA", "01:00.6"}, { "Alex" , "KUPRA", "01:04.6"},
                                     { "James" , "TOCUS", "01:05.1"}, { "Bob" , "TOCUS", "01:20.6"}
            },
            {
                                     { "Melo" , "BOSSCAR", "00:40.0"}, { "Johny" , "SUPERCAR", "00:42.9"}, { "Paul" , "BOSSCAR", "00:44.1"},
                                     { "Nicki" , "SUPERCAR", "00:45.3"}, { "Karen" , "KUPRA", "00:46.2"}, { "Alex" , "KUPRA", "00:48.1"},
                                     { "James" , "TOCUS", "00:54.1"}, { "Bob" , "TOCUS", "01:07.0"}
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
