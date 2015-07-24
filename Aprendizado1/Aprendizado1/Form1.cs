using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpSenses;

namespace Aprendizado1
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer Tempo = new System.Windows.Forms.Timer();

        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;


        public string Orientacao;
        ICamera cam = Camera.Create();
        
        public static void ClickDoMouse(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        public static void MoveMouse(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public Form1()
        {
            InitializeComponent();
         }
            
  
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Tempo.Start();
            if (e.KeyChar.ToString() == "k")
            {
                Orientacao = "PraBaixo";
            }
            else if (e.KeyChar.ToString() == "i")
            {
                Orientacao = "PraCima";
            }
            else if (e.KeyChar.ToString() == "l")
            {
                Orientacao = "PraDireita";
            }
            else if (e.KeyChar.ToString() == "j")
            {
                Orientacao = "PraEsquerda";
            }

            else if (e.KeyChar.ToString() == "p")
            {
                Tempo.Stop();
            }
            else if (e.KeyChar.ToString() == "c")
            {
                Tempo.Stop();
                ClickDoMouse(Cursor.Position.X, Cursor.Position.Y);
            }

        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Clic");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Orientacao = "Pausa";

            
            Tempo.Tick += new EventHandler(Evento);
            Tempo.Interval = 50;

            Tempo.Start();
            
            //SupportedLanguage.PtBR;

            cam.Start();

            cam.Face.WinkedRight += (self, eventArgs) =>
            {
                if (Orientacao == "Pausa")
                {
                    ClickDoMouse(Cursor.Position.X, Cursor.Position.Y);
                }
                else
                {
                    Orientacao = "Pausa";
                }

            };

            cam.Face.LeftEye.DoubleBlink += (self, eventArgs) =>
            {                
               if (Orientacao == "Pausa")
               {               
                   Orientacao = "PraDireita";
                   Tempo.Interval = 50;
               }
               else if (Orientacao == "PraDireita")
               {
                   Orientacao = "PraEsquerda";
               }
               else if (Orientacao == "PraEsquerda")
               {
                   Orientacao = "PraCima";
               }
               else if (Orientacao == "PraCima")
               {
                   Orientacao = "PraBaixo";
               }

               else if (Orientacao == "PraBaixo")
               {
                   Orientacao = "PraDireita";
               }
               else Orientacao = "PraDireita";

            };
           

             


        }

        private  void Evento(Object myObject,
                                                EventArgs myEventArgs)
        {
            if (Orientacao == "PraBaixo")
            {

                MoveMouse(Cursor.Position.X, Cursor.Position.Y + 3);
            }
            else if (Orientacao == "PraCima")
            {
                MoveMouse(Cursor.Position.X, Cursor.Position.Y - 3);
            }
            else if(Orientacao == "PraDireita")
            {
                MoveMouse(Cursor.Position.X + 3, Cursor.Position.Y);
            }
            else if(Orientacao == "PraEsquerda")
            {
                MoveMouse(Cursor.Position.X - 3, Cursor.Position.Y);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicou");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("BOM DIA", SupportedLanguage.PtBR);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("BOA TARDE", SupportedLanguage.PtBR);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("BOM NOITE", SupportedLanguage.PtBR);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("COMO VAI", SupportedLanguage.PtBR);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("CERTO", SupportedLanguage.PtBR);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("OLA TDC", SupportedLanguage.PtBR);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("SIM", SupportedLanguage.PtBR);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("NAO", SupportedLanguage.PtBR);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("ERRADO", SupportedLanguage.PtBR);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("CARAMBA", SupportedLanguage.PtBR);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("TURMA BOA", SupportedLanguage.PtBR);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("VAI", SupportedLanguage.PtBR);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("TCHAU", SupportedLanguage.PtBR);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("A", SupportedLanguage.PtBR);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("B", SupportedLanguage.PtBR);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("C", SupportedLanguage.PtBR);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("D", SupportedLanguage.PtBR);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("E", SupportedLanguage.PtBR);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cam.Speech.Say("VEM", SupportedLanguage.PtBR);
        }
    }
}
