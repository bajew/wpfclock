using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;

namespace Clock.ViewModel
{
    class Zeit : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Zeit()
        {
            _CurrentTime = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(ClockTimerElapsed);
            timer.Start();
        }

        private void ClockTimerElapsed(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now;
        }

        private DateTime _CurrentTime;
        public DateTime CurrentTime
        {
            get { return _CurrentTime; }
            set
            {
                if (_CurrentTime != value)
                {
                    _CurrentTime = value;
                    if (_CurrentTime.Hour > 18)
                    {
                        BackgroundColor = "#282a2e";
                        TextColor = "#c5c8c6";
                    }
                    else
                    {
                        TextColor = "#282a2e";
                        BackgroundColor = "#c5c8c6";
                    }
                    
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTime)));
                }
            }
        }

        private string _TextColor;
        public string TextColor
        {
            get { return _TextColor; }
            set
            {
                if (_TextColor != value)
                {
                    _TextColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextColor)));
                }
            }
        }

        private string _BackgroundColor;
        public string BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                if (_BackgroundColor != value)
                {
                    _BackgroundColor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackgroundColor)));
                }
            }
        }




    }
}
