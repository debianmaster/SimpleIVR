using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech;
using SpeechLib;  //com -> microsoft speech
using System.IO.Ports;
using System.Timers;
namespace TTS
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static SerialPort com1; 
        private static SpVoice voice;
		private static Boolean callInProgress=false;
        static void Main(string[] args)
        {
            try
            {
                com1 = new SerialPort("COM1");
                aTimer = new System.Timers.Timer(10000);               
                voice = new SpVoice();                                             
                com1.BaudRate = 9600;
                com1.Parity = Parity.None;
                com1.DataBits = 8;
                com1.StopBits = StopBits.One;
                com1.ReadTimeout = 3000;
                com1.WriteTimeout = 3000;
                com1.NewLine = "\r\n";
				Console.WriteLine("Connecting Modem....");	
                if (!com1.IsOpen)
                {
                    com1.Open();                   
					Console.WriteLine("Modem connected!");
                    System.Threading.Thread.Sleep(2000);
                    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    aTimer.Interval = 2000;
                    aTimer.Enabled = true;
                }              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (com1.IsOpen)
            {		
				String out1 = com1.ReadExisting().ToString();
				Console.WriteLine(out1);
                if (out1.Contains("\r\nRING\r\n") && callInProgress==false)
                {										
					callInProgress=true;
					Console.WriteLine("Incoming call.. Answering now");                    
					//com1.WriteLine("ATA");		                                        
                    System.Threading.Thread.Sleep(1000);
                    voice.Speak("Hello, chakri is not available at this moment. This is a test, IVR with basic bulk call feature. Thank you.", SpeechVoiceSpeakFlags.SVSFDefault);
					com1.WriteLine("ATH");
					out1="";
					callInProgress=false;					
                }
            }
            Console.WriteLine("Checking for incoming calls");
        }
    }
}