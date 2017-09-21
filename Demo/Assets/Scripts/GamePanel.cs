using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine;

public class GamePanel : MonoBehaviour {

    /// <summary>
    /// refer to the current game storyline
    /// </summary>
    public GamePrototype thisGame;


    /// <summary>
    /// Where a new game start
    /// </summary>
    public void StartGame()
    {
      thisGame = new GamePrototype();
   
    }

    /// <summary>
    /// store the current gameinfo into the reference of the saveload for the preparation of the saving data
    /// </summary>
    public void save()
    {
        SaveLoad.gameInfo = thisGame;
    }

    /// <summary>
    /// load the gameinfo from the reference of the loading data to overwrite the current gameinfo
    /// </summary>
    public void load()
    {
        thisGame = SaveLoad.gameInfo;
    }


}





public static class SaveLoad
{
    public static GamePrototype gameInfo;

 
    //it's static so we can call it from anywhere
    public static void Save()
    {
     
        BinaryFormatter bf = new BinaryFormatter();

        /// <summary>
        /// surrogate used for vector3 serialization
        /// </summary>
        {

            // 1. Construct a SurrogateSelector object
            SurrogateSelector ss = new SurrogateSelector();

            Vector3SerializationSurrogate v3ss = new Vector3SerializationSurrogate();
            ss.AddSurrogate(typeof(Vector3),
                            new StreamingContext(StreamingContextStates.All),
                            v3ss);

            // 2. Have the formatter use our surrogate selector
            bf.SurrogateSelector = ss;

        }



        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
       // FileStream file = File.Create("C:/Users/lily217/desktop/savedGames.gd");
        bf.Serialize(file, gameInfo);

        file.Close();
    }

    /// <summary>
    /// if haven't saved or cannot find the file return false otherwise true
    /// </summary>
    /// <returns></returns>
    public static bool Load()
    {
        //if (File.Exists("C:/Users/lily217/desktop/savedGames.gd"))
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {

            BinaryFormatter bf = new BinaryFormatter();


            /// <summary>
            /// surrogate used for vector3 serialization
            /// </summary>
            {

                // 1. Construct a SurrogateSelector object
                SurrogateSelector ss = new SurrogateSelector();

                Vector3SerializationSurrogate v3ss = new Vector3SerializationSurrogate();
                ss.AddSurrogate(typeof(Vector3),
                                new StreamingContext(StreamingContextStates.All),
                                v3ss);

                // 2. Have the formatter use our surrogate selector
                bf.SurrogateSelector = ss;

            }


            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
           
               // FileStream file = File.Open("C:/Users/lily217/desktop/savedGames.gd", FileMode.Open);
          
            gameInfo = (GamePrototype)bf.Deserialize(file);


            file.Close();
            return true;
        }
        else { return false; }
    }
}

sealed class Vector3SerializationSurrogate : ISerializationSurrogate
{

    // Method called to serialize a Vector3 object
    public void GetObjectData(System.Object obj,
                              SerializationInfo info, StreamingContext context)
    {

        Vector3 v3 = (Vector3)obj;
        info.AddValue("x", v3.x);
        info.AddValue("y", v3.y);
        info.AddValue("z", v3.z);
        Debug.Log(v3);
    }

    // Method called to deserialize a Vector3 object
    public System.Object SetObjectData(System.Object obj,
                                       SerializationInfo info, StreamingContext context,
                                       ISurrogateSelector selector)
    {

        Vector3 v3 = (Vector3)obj;
        v3.x = (float)info.GetValue("x", typeof(float));
        v3.y = (float)info.GetValue("y", typeof(float));
        v3.z = (float)info.GetValue("z", typeof(float));
        obj = v3;
        return obj;   // Formatters ignore this return value //Seems to have been fixed!
    }
}

