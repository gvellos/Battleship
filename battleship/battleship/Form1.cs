using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace battleship
{
    public partial class Form1 : Form
    {
        string nameb;
        string name;

        int[,] userArray = new int[10, 10];
        int[,] botArray = new int[10, 10];
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<PictureBox> pictureBoxesUser = new List<PictureBox>();
        List<string> randCordinates = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            Random random = new Random();
            List<string> userShips = new List<string>();
            List<string> botShips = new List<string>();
            userShips.Add("Aeroplanoforo");
            userShips.Add("Antitorpiliko");
            userShips.Add("Polemiko");
            userShips.Add("Ypovrixio");

            botShips.Add("Aeroplanoforo");
            botShips.Add("Antitorpiliko");
            botShips.Add("Polemiko");
            botShips.Add("Ypovrixio");

            int locx = 100;
            int locy = 100;
            int locbx = 500;
            int locby = 100;

            
            
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    userArray[i, y] = 0;
                    botArray[i, y] = 0;
                }
            }

            insertShip(userArray, userShips, random);
            insertShip(botArray, botShips, random);

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    name = $"{i},{y}";
                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.Name = $"{name}";
                    picturebox1.Location = new Point(locx, locy);
                    picturebox1.Size = new Size(25, 25);
                    picturebox1.BackColor = Color.Black;
                    picturebox1.ForeColor = Color.GhostWhite;
                    Controls.Add(picturebox1);
                    randCordinates.Add(name);
                    pictureBoxesUser.Add(picturebox1);
                    locx = locx + 30;
                    if (userArray[i, y] == 1)
                    {
                        picturebox1.BackColor = Color.Gray;
                    } 
                }
                locy = locy + 30;
                locx = locx - 300;
            }

            var result = randCordinates.OrderBy(item => random.Next()).ToList();
            for(int i = 0; i < result.Count; i++)
            {
                randCordinates[i] = result[i];
            }

            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    nameb = $"{i},{y}";                    
                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.Name = $"{nameb}";
                    picturebox1.Location = new Point(locbx, locby);
                    picturebox1.Size = new Size(25, 25);
                    picturebox1.BackColor = Color.Black;
                    picturebox1.ForeColor = Color.GhostWhite;
                    picturebox1.MouseDown += Picturebox1_MouseDown;
                    pictureBoxes.Add(picturebox1);
                    Controls.Add(picturebox1);
                    locbx = locbx + 30;
                }
                locby = locby + 30;
                locbx = locbx - 300;
            }
        }
        void Picturebox1_MouseDown(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                string name  = ((PictureBox)sender).Name;
                string[] result = name.Split(',');
                int x = Int32.Parse(result[0]);
                int y = Int32.Parse(result[1]);
                foreach(PictureBox picturebox in pictureBoxes)
                {
                    if(picturebox.Name == name)
                    {
                        if (botArray[x,y] == 1)
                        {
                            picturebox.BackColor = Color.Green;
                        }
                        else
                        {
                            picturebox.BackColor = Color.Red;
                        }
                        string resultBotForUser = randCordinates[0];
                        string[] resultBotCordinates = resultBotForUser.Split(',');
                        int xBot = Int32.Parse(resultBotCordinates[0]);
                        int yBot = Int32.Parse(resultBotCordinates[1]);
                        randCordinates.RemoveAt(0);


                        
                        PictureBox tempPictureBox = pictureBoxesUser[xBot * 10 + yBot];
                        if (userArray[xBot, yBot] == 1)
                        {
                            tempPictureBox.BackColor = Color.Green;
                        }
                        else
                        {
                            tempPictureBox.BackColor = Color.Red;
                        }
                    }
                }
            }
        }


        public void insertShip(int[,] shipArray , List<string> shipNames, Random random)
        {
           
            int tempxy = random.Next(0, 2);
            int tempx = random.Next(0, 6); //orizontia
            int tempy = random.Next(0, 6); // katheta
            if (shipNames[0] == "Aeroplanoforo")
            {
                if (tempxy == 0) // θα ειναι καθετα τα πλοια
                {
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx + 1, tempy] = 1;
                    shipArray[tempx + 2, tempy] = 1;
                    shipArray[tempx + 3, tempy] = 1;
                    shipArray[tempx + 4, tempy] = 1;
                }
                else
                {
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx, tempy + 1] = 1;
                    shipArray[tempx, tempy + 2] = 1;
                    shipArray[tempx, tempy + 3] = 1;
                    shipArray[tempx, tempy + 4] = 1;
                }
            }

            if (shipNames[1] == "Antitorpiliko")
            {
                tempx = random.Next(0, 7); // orizontia
                tempy = random.Next(0, 7);
                tempxy = random.Next(0, 2);
                if (tempxy == 0) // το πλοιο θα ειναι καθετα
                {
                    while (shipArray[tempx, tempy] == 1 || shipArray[tempx + 1, tempy] == 1 || shipArray[tempx + 2, tempy] == 1 || shipArray[tempx + 3, tempy] == 1)
                    {
                        tempx = random.Next(0, 7); // orizontia
                    }
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx + 1, tempy] = 1;
                    shipArray[tempx + 2, tempy] = 1;
                    shipArray[tempx + 3, tempy] = 1;
                }
                else
                {
                    while (shipArray[tempx, tempy] == 1 || shipArray[tempx, tempy + 1] == 1 || shipArray[tempx, tempy + 2] == 1 || shipArray[tempx, tempy + 3] == 1)
                    {
                        tempy = random.Next(0, 7);
                    }
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx, tempy + 1] = 1;
                    shipArray[tempx, tempy + 2] = 1;
                    shipArray[tempx, tempy + 3] = 1;
                }
            }

            if (shipNames[2] == "Polemiko")
            {
                tempx = random.Next(0, 8);
                tempy = random.Next(0, 8);
                tempxy = random.Next(0, 2);
                if (tempxy == 0)// το πλοιο θα ειναι καθετα
                {
                    while (shipArray[tempx, tempy] == 1 || shipArray[tempx + 1, tempy] == 1 || shipArray[tempx + 2, tempy] == 1)
                    {
                        tempx = random.Next(0, 8); // orizontia
                    }
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx + 1, tempy] = 1;
                    shipArray[tempx + 2, tempy] = 1;
                }
                else // το πλοιο θα ειναι orizontia
                {
                    while (shipArray[tempx, tempy] == 1 || shipArray[tempx, tempy + 1] == 1 || shipArray[tempx, tempy + 2] == 1)
                    {
                        tempy = random.Next(0, 8);
                    }
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx, tempy + 1] = 1;
                    shipArray[tempx, tempy + 2] = 1;
                }
            }

            if (shipNames[3] == "Ypovrixio")
            {
                tempx = random.Next(0, 9);
                tempy = random.Next(0, 9);
                tempxy = random.Next(0, 2);
                if (tempxy == 0)// το πλοιο θα ειναι καθετα
                {
                    while (shipArray[tempx, tempy] == 1 || shipArray[tempx + 1, tempy] == 1)
                    {
                        tempx = random.Next(0, 9); // orizontia
                    }
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx + 1, tempy] = 1;
                }
                else // το πλοιο θα ειναι orizontia
                {
                    while (shipArray[tempx, tempy] == 1 || shipArray[tempx, tempy + 1] == 1)
                    {
                        tempy = random.Next(0, 9);
                    }
                    shipArray[tempx, tempy] = 1;
                    shipArray[tempx, tempy + 1] = 1;
                }
            }
        }



       
        
    }
}
