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

namespace battleship
{
    public partial class Form1 : Form
    {
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
            string name = "1";
            int[,] userArray = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    userArray[i, y] = 0;
                }
            }

            int tempxy = random.Next(0, 2);
            int tempx = random.Next(0, 10);
            int tempy = random.Next(0, 10);
            if (userShips[0] == "Aeroplanoforo")
            { 
        
                if (tempxy == 0)
                {
                    if (tempx < 6)
                    {
                        userArray[tempx, tempy] = 1;
                        userArray[tempx + 1, tempy] = 1;
                        userArray[tempx + 2, tempy] = 1;
                        userArray[tempx + 3, tempy] = 1;
                        userArray[tempx + 4, tempy] = 1;
                    }
                    else
                    {
                        do
                        {
                            tempx = random.Next(0, 10);
                            tempy = random.Next(0, 10);
                        } while (tempx >= 6);
                        userArray[tempx, tempy] = 1;
                        userArray[tempx + 1, tempy] = 1;
                        userArray[tempx + 2, tempy] = 1;
                        userArray[tempx + 3, tempy] = 1;
                        userArray[tempx + 4, tempy] = 1;
                    }
                }
                else
                {
                    if (tempy < 6)
                    {
                        userArray[tempx, tempy] = 1;
                        userArray[tempx, tempy + 1] = 1;
                        userArray[tempx, tempy + 2] = 1;
                        userArray[tempx, tempy + 3] = 1;
                        userArray[tempx, tempy + 4] = 1;
                    }
                    else
                    {
                        do
                        {
                            tempx = random.Next(0, 10);
                            tempy = random.Next(0, 10);
                        } while (tempy >= 6);
                        userArray[tempx, tempy] = 1;
                        userArray[tempx, tempy + 1] = 1;
                        userArray[tempx, tempy + 2] = 1;
                        userArray[tempx, tempy + 3] = 1;
                        userArray[tempx, tempy + 4] = 1;
                    }
                }
            }

            if (userShips[1] == "Antitorpiliko")
            {
                 tempx = random.Next(0, 10);
                 tempy = random.Next(0, 10);
                 tempxy = random.Next(0, 2);
                if (tempxy == 0)
                {
                    while (tempx > 6 && (userArray[tempx, tempy] == 1 && userArray[tempx + 1, tempy] == 1 && userArray[tempx + 2, tempy] == 1 && userArray[tempx + 3, tempy] == 1))
                    {
                        tempx = random.Next(0, 10);
                        tempy = random.Next(0, 10);
                    }
                    userArray[tempx, tempy] = 1;
                    userArray[tempx + 1, tempy] = 1;
                    userArray[tempx + 2, tempy] = 1;
                    userArray[tempx + 3, tempy] = 1;
                }
                else
                {
                    while (tempy > 6 && (userArray[tempx, tempy] == 1 && userArray[tempx, tempy + 1] == 1 && userArray[tempx, tempy + 2] == 1 && userArray[tempx, tempy + 3] == 1) )
                    {
                        tempx = random.Next(0, 10);
                        tempy = random.Next(0, 10);
                        
                    }
                    userArray[tempx, tempy] = 1;
                    userArray[tempx, tempy + 1] = 1;
                    userArray[tempx, tempy + 2] = 1;
                    userArray[tempx, tempy + 3] = 1;
                }
            }

            if (userShips[2] == "Polemiko")
            {
                tempx = random.Next(0, 10);
                tempy = random.Next(0, 10);
                tempxy = random.Next(0, 2);
                if (tempxy == 0)
                {
                    while (tempx > 7 && (userArray[tempx, tempy] == 1 && userArray[tempx + 1, tempy] == 1 && userArray[tempx + 2, tempy] == 1 ))
                    {
                        tempx = random.Next(0, 10);
                        tempy = random.Next(0, 10);
                    }
                    userArray[tempx, tempy] = 1;
                    userArray[tempx + 1, tempy] = 1;
                    userArray[tempx + 2, tempy] = 1;
                }
                else
                {
                    while (tempy > 6 && (userArray[tempx, tempy] == 1 && userArray[tempx, tempy + 1] == 1 && userArray[tempx, tempy + 2] == 1 ))
                    {
                        tempx = random.Next(0, 10);
                        tempy = random.Next(0, 10);

                    }
                    userArray[tempx, tempy] = 1;
                    userArray[tempx, tempy + 1] = 1;
                    userArray[tempx, tempy + 2] = 1;
                }
            }



            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {

                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.Name = $"picturebox{name}";
                    picturebox1.Location = new Point(locx, locy);
                    picturebox1.Size = new Size(25, 25);
                    picturebox1.BackColor = Color.Black;
                    picturebox1.ForeColor = Color.GhostWhite;
                    Controls.Add(picturebox1);
                    name = $"{i}{y}";
                    locx = locx + 30;
                    if (userArray[i, y] == 1)
                    {
                        picturebox1.BackColor = Color.Gray;
                    }
                }
                locy = locy + 30;
                locx = locx - 300;
            }


           int locbx = 500;
            int locby = 100;
            string nameb = "1";
            int[,] botArray = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int y = 0; y < 10; y++)
                {
                    botArray[i, y] = 0;
                    PictureBox picturebox1 = new PictureBox();
                    picturebox1.Name = $"picturebox{nameb}";
                    picturebox1.Location = new Point(locbx, locby);
                    picturebox1.Size = new Size(25, 25);
                    picturebox1.BackColor = Color.Black;
                    picturebox1.ForeColor = Color.GhostWhite;
                    Controls.Add(picturebox1);
                    nameb = $"{i}{y}";
                    locbx = locbx + 30;
                }
                locby = locby + 30;
                locbx = locbx - 300;
            }
        }

        public int Line(int[,] arr, int line ,int position)
        {
            int counter = 0;
            int max = 0;
            int y = 0;
            int pos = 0;

            for ( y = 0; y < 10; y++)
            {
                if (arr[y,line] == 0)
                {
                    counter++;
                }
                else
                {

                    if (counter>max)
                    {
                        max = counter;
                        pos = y;
                    }
                    counter = 0;
                }
            }

            if (counter > max)
            {
                max = counter;
                pos = y;
            }
            if(max >= position)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }



        public int Liney(int[,] arr, int line, int position)
        {
            int counter = 0;
            int max = 0;
            int y = 0;
            int pos = 0;

            for (y = 0; y < 10; y++)
            {
                if (arr[line, y] == 0)
                {
                    counter++;
                }
                else
                {

                    if (counter > max)
                    {
                        max = counter;
                        pos = y;
                    }
                    counter = 0;
                }
            }

            if (counter > max)
            {
                max = counter;
                pos = y;
            }
            if (max >= position)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
    }
}
