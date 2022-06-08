using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Authing.Guard.WPF.Enums;
using Authing.Guard.WPF.Utils;

namespace Authing.Guard.WPF.Controls
{
    public class TransitioningContentControl : ContentControl
    {
        private FrameworkElement _contentPresenter;
        private static Storyboard StoryboardBuildInDefault;
        private Storyboard _storyboardBuildIn;
        public static readonly DependencyProperty TransitionModeProperty = DependencyProperty.Register(nameof(TransitionMode), typeof(TransitionMode), typeof(TransitioningContentControl), new PropertyMetadata((object)TransitionMode.Right2Left, new PropertyChangedCallback(TransitioningContentControl.OnTransitionModeChanged)));
        public static readonly DependencyProperty TransitionStoryboardProperty = DependencyProperty.Register(nameof(TransitionStoryboard), typeof(Storyboard), typeof(TransitioningContentControl), new PropertyMetadata((object)null));

        public TransitioningContentControl()
        {
            this.Loaded += new RoutedEventHandler(this.TransitioningContentControl_Loaded);
            this.Unloaded += new RoutedEventHandler(this.TransitioningContentControl_Unloaded);
        }

        private static void OnTransitionModeChanged(
          DependencyObject d,
          DependencyPropertyChangedEventArgs e)
        {
            ((TransitioningContentControl)d).OnTransitionModeChanged((TransitionMode)e.NewValue);
        }

        private void OnTransitionModeChanged(TransitionMode newValue)
        {
            this._storyboardBuildIn = ResourceHelper.GetResourceInternal<Storyboard>(string.Format("{0}Transition", (object)newValue));
            this.StartTransition();
        }

        public TransitionMode TransitionMode
        {
            get => (TransitionMode)this.GetValue(TransitioningContentControl.TransitionModeProperty);
            set => this.SetValue(TransitioningContentControl.TransitionModeProperty, (object)value);
        }

        public Storyboard TransitionStoryboard
        {
            get => (Storyboard)this.GetValue(TransitioningContentControl.TransitionStoryboardProperty);
            set => this.SetValue(TransitioningContentControl.TransitionStoryboardProperty, (object)value);
        }

        private void TransitioningContentControl_IsVisibleChanged(
          object sender,
          DependencyPropertyChangedEventArgs e)
        {
            this.StartTransition();
        }

        private void TransitioningContentControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.StartTransition();
            this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.TransitioningContentControl_IsVisibleChanged);
        }

        private void TransitioningContentControl_Unloaded(object sender, RoutedEventArgs e) => this.IsVisibleChanged -= new DependencyPropertyChangedEventHandler(this.TransitioningContentControl_IsVisibleChanged);

        private void StartTransition()
        {
            if (!this.IsArrangeValid || this._contentPresenter == null)
                return;
            if (this.TransitionStoryboard != null)
                this.TransitionStoryboard.Begin(this._contentPresenter);
            else if (this._storyboardBuildIn != null)
            {
                this._storyboardBuildIn?.Begin(this._contentPresenter);
            }
            else
            {
                if (TransitioningContentControl.StoryboardBuildInDefault == null)
                    TransitioningContentControl.StoryboardBuildInDefault = ResourceHelper.GetResourceInternal<Storyboard>(string.Format("{0}Transition", (object)TransitionMode.Right2Left));
                TransitioningContentControl.StoryboardBuildInDefault?.Begin(this._contentPresenter);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this._contentPresenter = VisualTreeHelper.GetChild((DependencyObject)this, 0) as FrameworkElement;
            if (this._contentPresenter == null)
                return;
            this._contentPresenter.RenderTransformOrigin = new Point(0.5, 0.5);
            this._contentPresenter.RenderTransform = (Transform)new TransformGroup()
            {
                Children = {
          (Transform) new ScaleTransform(),
          (Transform) new SkewTransform(),
          (Transform) new RotateTransform(),
          (Transform) new TranslateTransform()
        }
            };
        }
    }
}