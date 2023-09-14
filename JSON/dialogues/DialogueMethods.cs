using System;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;
using AntMaze.GameCycle;
using System.IO;

namespace AntMaze.JSON.dialogues
{
    public class DialogueMethods
    {
        public int Id { get; set; }
        public string dialogue { get; set; }

        Random random = new Random();

        public static string PathFinder(string pathName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string savePath = Path.Combine(projectDirectory, "JSON", "dialogues", pathName);
            savePath = savePath.Replace('\\', '/');
            return savePath;
        //C: \Users\Pofu\Desktop\Projects\GitHub\TextBasedGame\JSON\dialogues\dialogue.json
        }
        string savePath = PathFinder("dialogue.json");

        public string WriteRandomDialogue()
        {
            string json = System.IO.File.ReadAllText(savePath);
            List<DialogueMethods> dialogues = JsonConvert.DeserializeObject<List<DialogueMethods>>(json);
            int randomIndex = random.Next(0, dialogues.Count);
            DialogueMethods randomDialogue = dialogues[randomIndex];
            return randomDialogue.dialogue;
        }
    }
}