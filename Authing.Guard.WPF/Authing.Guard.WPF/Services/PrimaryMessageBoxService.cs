using Authing.Guard.WPF.Controls;
using Authing.Guard.WPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Authing.Guard.WPF.Services
{
    public class PrimaryMessageBoxService
    {
        private static List<PrimaryMessageBox> m_BoxList;

        private PrimaryMessageBoxService()
        {

        }

        public static void Show(string message, IconType iconType, double x = 0, double y = 0)
        {
            PrimaryMessageBox primaryMessageBox = new PrimaryMessageBox();
            primaryMessageBox.ShowInTaskbar = false;
            primaryMessageBox.Message = message;
            primaryMessageBox.IconType = iconType;

            primaryMessageBox.Show();

            if (m_BoxList == null)
            {
                m_BoxList = new List<PrimaryMessageBox>();
            }

            if (x == 0 && y == 0)
            {
                x = Application.Current.MainWindow.Left +(Application.Current.MainWindow.Width/ 2)-primaryMessageBox.ActualWidth/2;
                y = Application.Current.MainWindow.Top  +10;
            }

            double top = 0;
            if (m_BoxList.Count > 0)
            {
                top = m_BoxList.LastOrDefault().Top + primaryMessageBox.ActualHeight + 10;
            }

            if (top != 0)
            {
                primaryMessageBox.Top = top;
            }
            else
            {
                primaryMessageBox.Top = y;
            }
            primaryMessageBox.Left = x;

            primaryMessageBox.OnClose += CloseMessageBox;

            m_BoxList.Add(primaryMessageBox);
        }

        private static void CloseMessageBox(int id)
        {
            for (int i = m_BoxList.Count-1; i>=1; i--)
            {
                m_BoxList[i].Top = m_BoxList[i - 1].Top;

            }

            m_BoxList.Remove(m_BoxList.Where(p => p.GetHashCode() == id).FirstOrDefault());


        }
    }
}
