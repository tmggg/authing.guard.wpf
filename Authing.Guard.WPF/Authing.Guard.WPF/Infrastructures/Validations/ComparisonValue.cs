using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Authing.Guard.WPF.Infrastructures.Validations
{
    public class ComparisonValue : DependencyObject
    {
        public bool IsNessery
        {
            get { return (bool)GetValue(IsNesseryProperty); }
            set { SetValue(IsNesseryProperty, value); }
        }

        public static readonly DependencyProperty IsNesseryProperty = DependencyProperty.Register(
            nameof(IsNessery),
            typeof(bool),
            typeof(ComparisonValue),
            new PropertyMetadata(default(bool), OnValueChanged));

        public static readonly DependencyProperty DataNameProperty = DependencyProperty.Register(
            "DataName", typeof(string), typeof(ComparisonValue), new PropertyMetadata(default(string)));

        public string DataName
        {
            get { return (string)GetValue(DataNameProperty); }
            set { SetValue(DataNameProperty, value); }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ComparisonValue comparisonValue = (ComparisonValue)d;
            BindingExpressionBase bindingExpressionBase = BindingOperations.GetBindingExpressionBase(comparisonValue, BindingToTriggerProperty);
            bindingExpressionBase?.UpdateSource();
        }

        public object BindingToTrigger
        {
            get { return GetValue(BindingToTriggerProperty); }
            set { SetValue(BindingToTriggerProperty, value); }
        }

        public static readonly DependencyProperty BindingToTriggerProperty = DependencyProperty.Register(
            nameof(BindingToTrigger),
            typeof(object),
            typeof(ComparisonValue),
            new FrameworkPropertyMetadata(default(object), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}