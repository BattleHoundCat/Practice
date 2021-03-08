using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace MultiThreadApp
{
    public partial class MainForm : Form
    {
        public class TemperatureInfo
        {
            public float Temp { get; set; }
        }
        public class WeatherResponse
        {
            public TemperatureInfo Main { get; set; }

            public string Name { get; set; }

            
        }
        public int ActiveTasks = 0;

        static public DateTime currentTime = DateTime.Now;

        string FullBook;

        string[] words;

        static int indexCounter = 0;
        List<System.Windows.Forms.Timer> timerlist = new List<System.Windows.Forms.Timer>();

        string targetPath = @"E:\Test\testlog.txt";

        public MainForm()
        {
            InitializeComponent();
            lblSumTasks.Text = $"All Active Tasks: {ActiveTasks}";
            System.Windows.Forms.Timer BasicTimer = new System.Windows.Forms.Timer();
            System.Windows.Forms.Timer WeatherTimer = new System.Windows.Forms.Timer();
            System.Windows.Forms.Timer TextTimer = new System.Windows.Forms.Timer();
            timerlist.Add(BasicTimer);
            timerlist.Add(WeatherTimer);
            timerlist.Add(TextTimer);

        }

        private void btnWeatherProcess_Click(object sender, EventArgs e)
        {
            //GetWeather();
            timerlist[1].Tick += new EventHandler(GetWeather);
            timerlist[1].Interval = 4000;
            timerlist[1].Start();
            btnWeatherProcess.Enabled = false;
            UpActivePTasks();

        }
        private void GetWeather(object sender, EventArgs e)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Moscow,Ru&units=metric&appid=51d01be8c740b9dfd598d0d246ec6adb";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            txtBoxWeather.Text = $"Temperature in {weatherResponse.Name}: {weatherResponse.Main.Temp} °C";
        }

        private void btnTimerProcess_Click(object sender, EventArgs e)
        {

            txtBoxTimer.Text = currentTime.ToString();
            btnTimerProcess.Enabled = false;
            timerlist[0].Tick += new EventHandler(TimerTick);
            timerlist[0].Interval = 5000;
            timerlist[0].Start();
            UpActivePTasks();

        }

        private void btnParseTextProcess_Click(object sender, EventArgs e)
        {
            ParseBook();
            timerlist[2].Tick += new EventHandler(InsertTextBlock);
            timerlist[2].Interval = 4000;
            timerlist[2].Start();
            btnParseTextProcess.Enabled = false;
            UpActivePTasks();

        }

        private void btnWriteLogProcess_Click(object sender, EventArgs e)
        {
            UpActivePTasks();
        }

        private void btnCloseAllTasks_Click(object sender, EventArgs e)
        {
            StopActiveTasks();
            btnCloseAllTasks.Enabled = false;
            this.Close();

        }

        private void UpActivePTasks()
        {
            ActiveTasks++;
            lblSumTasks.Text = $"All Active Tasks: {ActiveTasks}";
        }
        private void StopActiveTasks()
        {
            ActiveTasks = 0;
            foreach ( var mytimer in timerlist)
            {
                mytimer.Stop();
            }
            lblSumTasks.Text = $"All Active Tasks: {ActiveTasks}";
        }
        private void TimerTick(object sender, EventArgs e)
        {
            txtBoxTimer.Text = DateTime.Now.ToString();
        }
        private void ParseBook() 
        {
            WebClient wc = new WebClient();

            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                s = eArgs.Result;
                this.FullBook = (string)s;
                txtBoxText.Text = "Книга загружена";
                words = FullBook.Split(' ');
            };

            //  Загрузить  электронную  книгу  из Библиотеки Гутенберга.

            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/64630/64630-0.txt"));
        }
        /// <summary>
        /// Вставить блок текста раз в определенный интервал времени
        /// </summary>
        private void InsertTextBlock(object sender, EventArgs e)
        {
            txtBoxText.Text = "";
            txtBoxLogging.Text = "Готовится вставка новых данных";
            var query = from word in words
                        .Skip(indexCounter)
                        .Take(20)
                        select word;
            foreach(var i in query)
            {
                txtBoxText.Text += i.ToString();
                txtBoxText.Text += ' ';
            }
            indexCounter += 20;
            timerlist[2].Stop();
            Application.DoEvents();
            txtBoxLogging.Text = "Новые слова получены";
            Thread.Sleep(1500);               
            //запустить лог в файл
            LogIntoFile(txtBoxText.Text);

        }
        private async void LogIntoFile(string inputWords)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(targetPath, append: true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(inputWords);
                }
                txtBoxLogging.Text = "Запись выполнена";
            }
            catch (Exception e)
            {
                txtBoxLogging.Text = e.Message;
            }
            timerlist[2].Start();
        }
    }
}
