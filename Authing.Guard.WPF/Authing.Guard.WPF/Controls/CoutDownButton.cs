using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Authing.Guard.WPF.Controls
{
    [TemplatePart(Name = ElementMainBorder, Type = typeof(Border))]
    [TemplatePart(Name = ElementTipDockPanel, Type = typeof(DockPanel))]
    [TemplatePart(Name = BusyStoryBoard, Type = typeof(Storyboard))]
    [TemplatePart(Name = ElementBusyIconPath, Type = typeof(Path))]
    public class CoutDownButton : Button
    {
        #region 定义样式中存在的控件

        private const string ElementMainBorder = "PART_MainBorder";
        private const string ElementTipDockPanel = "PART_TipDockPanel";
        private const string ElementBusyIconPath = "PART_IconPath";
        private const string BusyStoryBoard = "BusyStoryBoard";

        #endregion 定义样式中存在的控件

        #region 字段

        private System.Timers.Timer _timer;
        private Border _mainBorder;
        private DockPanel _tipDockPanel;
        private uint _defultCount;
        private Storyboard _busyStoryBoard;
        private Path _IconPath;

        #endregion 字段

        /// <summary>
        /// 倒计时开始秒数
        /// </summary>
        public static readonly DependencyProperty CountProperty = DependencyProperty.Register(
            "Count", typeof(uint), typeof(CoutDownButton), new PropertyMetadata(default(uint)));

        /// <summary>
        /// 开启倒计时
        /// </summary>
        public static readonly DependencyProperty StartCountDownProperty = DependencyProperty.Register(
            "StartCountDown", typeof(bool), typeof(CoutDownButton), new PropertyMetadata(false));

        /// <summary>
        /// 繁忙处理
        /// </summary>
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(
            "IsBusy", typeof(bool), typeof(CoutDownButton), new PropertyMetadata(default(bool)));

        public uint Count
        {
            get { return (uint)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set
            {
                if (IsBusy != value)
                {
                    if (value)
                        _busyStoryBoard.Begin();
                    else
                        _busyStoryBoard.Stop();
                }
                SetValue(IsBusyProperty, value);
            }
        }

        public bool StartCountDown
        {
            get { return (bool)GetValue(StartCountDownProperty); }
            set
            {
                SetValue(StartCountDownProperty, value);
                if (value)
                    DoWork();
            }
        }

        private void DoWork()
        {
            if (_timer == null)
            {
                _timer = new System.Timers.Timer();
                _timer.Elapsed += DataTimer_Tick;
                _timer.Interval = 1000;
            }
            _defultCount = Count;
            _tipDockPanel.Visibility = Visibility.Visible;
            _mainBorder.Visibility = Visibility.Hidden;
            IsHitTestVisible = false;
            _timer.Start();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _mainBorder = GetTemplateChild(ElementMainBorder) as Border;
            _tipDockPanel = GetTemplateChild(ElementTipDockPanel) as DockPanel;
            _IconPath = GetTemplateChild(ElementBusyIconPath) as Path;
            _busyStoryBoard = MakeRotationAnimation(_IconPath);
        }

        private void DataTimer_Tick(object sender, EventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.DataBind, (ThreadStart)delegate
            {
                if (Count > 0)
                {
                    Count--;
                    if (Count == 0)
                    {
                        Count = _defultCount;
                        _timer.Stop();
                        _tipDockPanel.Visibility = Visibility.Hidden;
                        _mainBorder.Visibility = Visibility.Visible;
                        IsHitTestVisible = true;
                        StartCountDown = false;
                    }
                }
            });
        }

        private Storyboard MakeRotationAnimation(DependencyObject obj)
        {
            Storyboard storyboard = new Storyboard() { RepeatBehavior = RepeatBehavior.Forever };
            storyboard.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            DoubleAnimation rotateAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                Duration = storyboard.Duration,
            };

            Storyboard.SetTarget(rotateAnimation, obj);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(UIElement.RenderTransform).(RotateTransform.Angle)"));

            storyboard.Children.Add(rotateAnimation);
            return storyboard;
        }
    }
}