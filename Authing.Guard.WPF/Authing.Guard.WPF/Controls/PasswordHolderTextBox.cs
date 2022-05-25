using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Authing.Guard.WPF.Controls
{
    public class PasswordHolderTextBox : PlaceHolderTextBox
    {
        /// <summary>
        /// 显示在输入框内的文字
        /// </summary>
        public string PlaceHolderShowText
        {
            get
            {
                return (string)GetValue(PlaceHolderShowTextProperty);
            }
            set
            {
                SetValue(PlaceHolderShowTextProperty, value);
            }
        }

        public static DependencyProperty PlaceHolderShowTextProperty = DependencyProperty.Register(nameof(PlaceHolderShowText), typeof(string), typeof(PasswordHolderTextBox), new PropertyMetadata(string.Empty, PlaceHolderShowTextPropertyChanged));

        private static void PlaceHolderShowTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //(d as PasswordHolderTextBox).Text = (string)e.NewValue;
            //string password = "";
            //for (int i = 0; i < (d as PasswordHolderTextBox).Text.Length; i++)
            //{
            //    password += "*";
            //}

            //   (d as PasswordHolderTextBox).PlaceHolderShowText = password;

        }

        /// <summary>
        /// 是否显示密码
        /// </summary>
        public bool ShowPassword
        {
            get
            {
                return (bool)GetValue(ShowPasswordProperty);
            }
            set
            {
                SetValue(ShowPasswordProperty, value);
            }
        }
        public static DependencyProperty ShowPasswordProperty = DependencyProperty.Register(nameof(ShowPassword), typeof(bool), typeof(PasswordHolderTextBox), new PropertyMetadata(false, ShowPasswordPropertyChanged));

        private static void ShowPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if ((bool)e.NewValue == true)
            //{
            //    (d as PasswordHolderTextBox).PlaceHolderShowText = (d as PasswordHolderTextBox).Text;
            //    // e.sour
            //}
            //else
            //{
            //    string password = "";
            //    for (int i = 0; i < (d as PasswordHolderTextBox).Text.Length; i++)
            //    {
            //        password += "*";
            //    }
            //     (d as PasswordHolderTextBox).PlaceHolderShowText = password;
            //}
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            //if (ShowPassword)
            //{
               // PlaceHolderShowText = Text;
            //}
            //else
            //{
            //    string password = "";
            //    for (int i = 0; i < Text.Length; i++)
            //    {
            //        password += "*";
            //    }

            //    PlaceHolderShowText = password;
            //}

            base.OnTextChanged(e);
        }
    }
}
