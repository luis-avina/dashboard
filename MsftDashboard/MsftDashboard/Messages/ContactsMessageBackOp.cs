﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MsftDashboard.Web.Models;
using System.Collections.ObjectModel;

namespace MsftDashboard.Messages
{
    internal class ContactsMessageBackOp
    {
        public int idOperation { get; set; }
        public Contact Contact { get; set; }
        public ObservableCollection<Contact> ContactCollection { get; set; }
    }
}
