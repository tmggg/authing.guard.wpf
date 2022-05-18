using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public static  DependencyProperty PlaceHolderShowTextProperty = DependencyProperty.Register(nameof(PlaceHolderShowText), typeof(string), typeof(PasswordHolderTextBox), new PropertyMetadata(string.Empty));


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
        public static DependencyProperty ShowPasswordProperty = DependencyProperty.Register(nameof(ShowPassword), typeof(bool), typeof(PasswordHolderTextBox), new PropertyMetadata(false));

    }
}
