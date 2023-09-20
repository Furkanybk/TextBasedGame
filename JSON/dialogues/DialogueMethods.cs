using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace AntMaze.JSON.dialogues
{
    public class DialogueMethods
    {
        public int Id;
        public string Dialogue;
        public string SavePath;
        private Random _random = new Random();

        private string PathFinder(string pathName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string savePath = Path.Combine(projectDirectory, "JSON", "dialogues", pathName);
            savePath = savePath.Replace('\\', '/');
            return savePath;
        }
      
        public void WriteRandomDialogue()
        {
            SavePath = PathFinder("dialogue.json");
            string json = System.IO.File.ReadAllText(SavePath);
            List<DialogueMethods> dialogues = JsonConvert.DeserializeObject<List<DialogueMethods>>(json);
            int randomIndex =_random.Next(0, dialogues.Count);
            DialogueMethods randomDialogue = dialogues[randomIndex];
            Console.WriteLine(randomDialogue.Dialogue); 
        }
    }
}