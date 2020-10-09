using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ClipboarStressTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Start Test?\nType Y or N");
            if (Console.ReadLine() == "Y")
                ClipboardTest.TextStressTest(10, 3000, 10);
        }
    }
    public static class ClipboardTest
    {
        [STAThread]
        public static void TextStressTest(int time, int span, int MaxtextLength)
        {
            Random rnd = new Random();
            for(int k =0;k<time;k++)
            {
                int length = rnd.Next(MaxtextLength+1);
                string TextToSet = null;
                for(int i =0;i<length;i++)
                {
                    char s = (char) rnd.Next(256+1);
                    TextToSet += s;
                }
                Thread.Sleep(span);
                if (TextToSet == null)
                    TextToSet = "NotRandomText";
                Clipboard.SetText(TextToSet);
            }
            Console.WriteLine("Test ended");
            Console.ReadLine();
        }
    }
}
