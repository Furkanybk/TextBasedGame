using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AntMaze.GameCycle;
using System.Threading;

namespace AntMaze.JSON.Save
{
    public class Save
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Room { get; set; }
        public int Health { get; set; }
        public int AttackDamage { get; set; }
        public int AbilityPower { get; set; }
        public int Agility { get; set; }
        public int Defense { get; set; }
    }

    public class SaveMethods
    {
        public List<Save> Saves { get; set; }
        private int nextId = 1;
        public bool controll = false;

        public static string PathFinder(string pathName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string savePath = Path.Combine(projectDirectory, "JSON", "Save", pathName);
            savePath = savePath.Replace('\\', '/');
            return savePath;
        }
        string savePath = PathFinder("Save.json");

        public SaveMethods()
        {

            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                Saves = JsonConvert.DeserializeObject<List<Save>>(json);
            }
            else
            {
                Saves = new List<Save>();
            }

            if (Saves.Count > 0)
            {
                nextId = Saves.Max(s => s.Id) + 1;
            }
        }

        public void SaveGame(Player player)
        {
            Save existingSave = Saves.Find(match => match.Id == nextId);

            if (existingSave != null)
            {
                // Var olan kaydı güncelle
                existingSave.Name = player.Name;
                existingSave.Room = player.CurrentRoom;
                existingSave.Health = player.Health;
                existingSave.AttackDamage = player.AttackDamage;
                existingSave.AbilityPower = player.AbilityPower;
                existingSave.Agility = player.Agility;
                existingSave.Defense = player.Defense;
            }
            else
            {
                // Yeni bir kayıt oluştur
                Save save = new Save
                {
                    Id = nextId,
                    Name = player.Name,
                    Room = player.CurrentRoom,
                    Health = player.Health,
                    AttackDamage = player.AttackDamage,
                    AbilityPower = player.AbilityPower,
                    Agility = player.Agility,
                    Defense = player.Defense
                };
                Saves.Add(save);
            }
            string json = JsonConvert.SerializeObject(Saves);
            File.WriteAllText(savePath, json);
        }

        public void LoadSaveGame(Player player)
        {

            Save existingSave = Saves.Find(match => match.Id == player.Id);
            if (existingSave != null)
            {

                existingSave.Name = player.Name;
                existingSave.Room = player.CurrentRoom;
                existingSave.Health = player.Health;
                existingSave.AttackDamage = player.AttackDamage;
                existingSave.AbilityPower = player.AbilityPower;
                existingSave.Agility = player.Agility;
                existingSave.Defense = player.Defense;
            }
            string json = JsonConvert.SerializeObject(Saves);
            File.WriteAllText(savePath, json);
        }

        public Player LoadGame(Player player)
        {
            string json;
            int playerChoose;
            bool controle = true;
            while (player.Name == null)
            {
                try { json = File.ReadAllText(savePath); }
                catch
                {
                    Console.WriteLine("Save not found:");
                    Thread.Sleep(1000);
                    break;
                }
                List<Save> loadedSaves = JsonConvert.DeserializeObject<List<Save>>(json);
                foreach (Save loadedSave in loadedSaves)
                {
                    if (loadedSave.Name == null) controle = false;
                    if (loadedSave.AttackDamage == 0) controle = false;
                    if (loadedSave.AttackDamage != 0) controle = true;
                }
                if (controle == false)
                {
                    Console.WriteLine("Save not found:");
                    Thread.Sleep(1000);
                    break;
                }


                foreach (Save save in loadedSaves)
                {

                    if (save.Name == null) { continue;}
                    Console.WriteLine(save.Id + "-)");
                    Console.WriteLine("Name: " + save.Name);
                    Console.WriteLine("Room: " + save.Room);
                    Console.WriteLine("-----------------");
                }
                try { playerChoose = Convert.ToInt32(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("Please Choose a valid option");
                    continue;
                }
                Save existingSave = loadedSaves.Find(x => x.Id == playerChoose);
                if (existingSave != null)
                {
                    player.Id = existingSave.Id;
                    player.Name = existingSave.Name;
                    player.CurrentRoom = existingSave.Room;
                    player.Health = existingSave.Health;
                    player.PlayerWeapon.AttackDamage = existingSave.AttackDamage;
                    player.PlayerWeapon.AbilityPower = existingSave.AbilityPower;
                    player.PlayerWeapon.Agility = existingSave.Agility;
                    player.PlayerWeapon.Defense = existingSave.Defense;
                }
                else
                {
                    Console.WriteLine("No such save found:");
                    break;
                }
            }
            return player;
        }
    }
}