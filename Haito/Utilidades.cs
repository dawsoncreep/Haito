﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Haito
{
    class Utilidades
    {
    }

    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                System.Windows.Forms.MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }

    enum unidadMedida
    {
          PZ = 1
        , Kg = 2
        , Ton = 3
        , Metro = 4
        , Lote = 5
        , Caja = 6
        , Tramo = 7
        , Cm = 8
        , Pulgada = 9
        , M2 = 10
        , M3 = 11
        , Libra = 12
        , Litro = 13
        , Galon = 14
        , Cubeta = 15
        , Gramo = 16
    }

    enum rol
    {
        admin = 1,
        usuario = 2
    }

    enum encabezado
    {
        IVAN = 0,
        HAITO = 1
    }
    enum moneda
    {
        MXN = 0,
        USD = 1
    }
    enum tipoProducto
    {
        Producto = 0,
        Servicio = 1
    }
}
